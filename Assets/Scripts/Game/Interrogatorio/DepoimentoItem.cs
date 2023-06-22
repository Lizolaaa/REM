using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Interrogatorio {
	public class DepoimentoItem : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI _textName;
		[SerializeField] private TextMeshProUGUI _textDepoimentos;
		[SerializeField] private UnityEvent _onClickName;

		private Button _button;
		private DepoimentosManager.Depoimento _depoimento;


		private void Awake() {
			this._button = this.GetComponentInChildren<Button>();
		}

		public void Initialize(DepoimentosManager.Depoimento depoimento, Action<DepoimentoItem> onClick) {
			this._depoimento = depoimento;
			this._textName.text = depoimento.Pessoa;
			this._textDepoimentos.text = string.Join(Environment.NewLine, depoimento.Depoimentos);
			this.gameObject.SetActive(true);

			this._button.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => {
				onClick?.Invoke(this);
				this._onClickName?.Invoke();
			});
		}
		
	}
}
