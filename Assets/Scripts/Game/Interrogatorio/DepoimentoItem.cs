using TMPro;
using UnityEngine;

namespace Game.Interrogatorio {
	public class DepoimentoItem : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI _text;
		private DepoimentosManager.Depoimento _depoimento;
		
		
		public void Initialize(DepoimentosManager.Depoimento depoimento) {
			this._depoimento = depoimento;
			this._text.text = depoimento.Pessoa;
			this.gameObject.SetActive(true);
		}
		
	}
}
