using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Quiz {
	public class QuizItem : MonoBehaviour {

		[HideInInspector] public string OptionText;
		private Action<QuizItem> OnClick;		
		[SerializeField] private Button _button;
		[SerializeField] private TextMeshProUGUI _text;
		
		
		public void Initialize(string text, Action<QuizItem> OnClick) {
			this.OptionText = text;
			this._text.text = text;
			this.OnClick = OnClick;
			this.gameObject.SetActive(true);
		}

		private void Awake() {
			this._button.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => {
				this.OnClick?.Invoke(this);
			});
		}
	}
}
