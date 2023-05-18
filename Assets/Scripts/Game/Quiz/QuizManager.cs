using System.Collections.Generic;
using System.Linq;
using CDK;
using TMPro;
using Unity.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Game.Quiz {
	public class QuizManager : MonoBehaviour {
		[System.Serializable]
		public class QuizQuestions {
			public string RightAnswer;
			public string[] WrongAnswers;
			public TextMeshProUGUI TargetTMP;
		}

		public List<QuizQuestions> Questions = new List<QuizQuestions>();
		private QuizQuestions[] _initialQuestions;
		private List<string> Answers = new List<string>();
		public Transform ParentContent;
		public QuizItem TemplateQuizItem;
		private QuizQuestions currentQuestion;

		[SerializeField] private UnityEvent _onRight;
		[SerializeField] private UnityEvent _onWrong;
		
		


		private void Awake() {
			_initialQuestions = this.Questions.ToArray();
			currentQuestion = this.Questions.First();
			Questions.Remove(currentQuestion);
			SpawnQuestions(currentQuestion);
			TemplateQuizItem.gameObject.SetActive(false);
		}


		private void SpawnQuestions(QuizQuestions questions) {
			DeleteQuestions();
			var item = Instantiate(this.TemplateQuizItem, this.ParentContent);
			item.Initialize(questions.RightAnswer, OnItemClicked);
			foreach (var option in questions.WrongAnswers) {
				item = Instantiate(this.TemplateQuizItem, this.ParentContent);
				item.Initialize(option, OnItemClicked);
			}
			ShuffleChildren(this.ParentContent);
		}

		void DeleteQuestions() {
			foreach (var c in this.ParentContent.gameObject.Children()) {
				c.CDestroy();
			}
		}
		

		public void OnItemClicked(QuizItem itemClicked) {
			currentQuestion.TargetTMP.text = itemClicked.OptionText;
			Answers.Add(itemClicked.OptionText);
			currentQuestion = this.Questions.FirstOrDefault();
			if (currentQuestion == null) {
				this.CheckResult();
				return;
			}
			Questions.Remove(currentQuestion);
			SpawnQuestions(currentQuestion);
		}

		void CheckResult() {
			bool isRight = true;
			
			var answerToCompare = Answers.Select(a => a.ToLowerInvariant().Trim()).ToArray();
			var rightAnswers = _initialQuestions.Select(q => q.RightAnswer.ToLowerInvariant().Trim()).ToArray();
			
			Debug.Log($"User Answers are: {string.Join(", ", answerToCompare)}");
			Debug.Log($"Quiz Right answers are: {string.Join(", ", rightAnswers)}");

			foreach (var answer in answerToCompare) {
				if (rightAnswers.Contains(answer)) continue;
				Debug.Log($"Answer '{answer}' is wrong.");
				isRight = false;
				break;
			}

			if (isRight) {
				Debug.Log("Quiz result: Is right");
				this._onRight?.Invoke();
			}
			else {
				Debug.Log("Quiz result: Is wrong");
				this._onWrong?.Invoke();
			}
		}
		
		

		public void ShuffleChildren(Transform target) {
			List<int> indexes = new List<int>();
			List<Transform> items = new List<Transform>();
			for (int i = 0; i < target.childCount;++i) {
				indexes.Add(i);
				items.Add(target.GetChild(i));
			}
         
			foreach (var item in items) {
				item.SetSiblingIndex(indexes[Random.Range(0, indexes.Count)]);
			}
		}
	}
}
