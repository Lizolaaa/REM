using System;
using TMPro;
using UnityEngine;

namespace Game.Interrogatorio {
	public class DepoimentoItem : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI _textName;
		[SerializeField] private TextMeshProUGUI _textDepoimentos;

		private DepoimentosManager.Depoimento _depoimento;

		
		
		public void Initialize(DepoimentosManager.Depoimento depoimento) {
			this._depoimento = depoimento;
			this._textName.text = depoimento.Pessoa;
			this._textDepoimentos.text = string.Join(Environment.NewLine, depoimento.Depoimentos);
			this.gameObject.SetActive(true);
		}
		
	}
}
