using UnityEngine;
using UnityEngine.EventSystems;

namespace Game {
	public class EvidenceItem : MonoBehaviour, IPointerClickHandler {

		public string EvidenceName;
		[SerializeField, Multiline] private string _text;
		[SerializeField] private string _buttonText;
		[SerializeField] private GameObject _screenToOpenOnClick;
		private InvestigationManager _investigationManager;

		
		

		private void Awake() {
			_investigationManager = FindObjectOfType<InvestigationManager>();
		}

		public void OnPointerClick(PointerEventData eventData) {
			this._investigationManager.OnEvidenceClicked(this, _text, _buttonText, _screenToOpenOnClick != null ? () => _screenToOpenOnClick.gameObject.SetActive(true) : null);
		}
		
	}
}
