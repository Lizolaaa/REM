using System;
using TMPro;
using UnityEngine;

namespace Game.Interrogatorio {
	public class DepoimentoItem : MonoBehaviour {

		private DepoimentosManager.Depoimento _depoimento;
		[SerializeField] private TextMeshProUGUI _nameText;
		[SerializeField] private TextMeshProUGUI _text;

		
		
		
		public void Initialize(DepoimentosManager.Depoimento depoimento) {
			this._depoimento = depoimento;
			this._nameText.text = depoimento.Pessoa;
			this._text.text = string.Join(Environment.NewLine, depoimento.Depoimentos);
			this.gameObject.SetActive(true);
		}
		
	}
}
