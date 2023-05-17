using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Quiz {
	public class QuizItem : MonoBehaviour {

		public string OptionText;
		private Action<QuizItem> OnClick;		
		[SerializeField] private Button _button;

		
		public void Initialize(string text, Action<QuizItem> OnClick) {
			this.OptionText = text;
			this.OnClick = OnClick;
		}

		private void Awake() {
			this._button.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => {
				this.OnClick?.Invoke(this);
			});
		}
	}
}
