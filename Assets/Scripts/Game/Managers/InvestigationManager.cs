using System;
using System.Collections.Generic;
using CDK;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game {
	public class InvestigationManager : MonoBehaviour {

		// Gather	
		public static List<string> CollectedEvidences = new List<string>();
		private List<EvidenceItem> _allEvidences = new List<EvidenceItem>();
		[SerializeField] private EvidenceItem _selectedEvidence;
		private int _evidencesGathered;
		[SerializeField] private TextMeshProUGUI _messageBoxText;
		[SerializeField] private TextMeshProUGUI _buttonText;
		[SerializeField] private Button _buttonEvidenceAction;
		private Action _overrideEvidenceAction;
		[SerializeField] private Button _buttonNextScreen;
		[SerializeField] private CSceneField _nextScene;
		
		

		private void Awake() {
			CollectedEvidences.Clear();
			this._allEvidences.AddRange(this.GetComponentsInChildren<EvidenceItem>(true));

			this._buttonEvidenceAction.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => {
				if (this._overrideEvidenceAction != null) {
					this._overrideEvidenceAction?.Invoke();
					return;
				}

				CollectEvidence(this._selectedEvidence);
			});
			
			this._buttonNextScreen.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => {
				SceneManager.LoadScene(_nextScene);
			});
		}

		public void OnEvidenceClicked(EvidenceItem evidence, string text, string buttonText, Action overrideAction) {
			this._selectedEvidence = evidence;
			this._messageBoxText.text = text;
			this._buttonText.gameObject.SetActive(!buttonText.CIsNullOrEmpty());
			this._buttonText.text = buttonText;
			this._overrideEvidenceAction = overrideAction;
		}

		private void CollectEvidence(EvidenceItem evidence) {
			if (!evidence) return;
			CollectedEvidences.Add(evidence.EvidenceName);
			evidence.gameObject.SetActive(false);
			OnEvidenceClicked(null, String.Empty, String.Empty, null);
			CheckForCompletion();
		}

		private void CheckForCompletion() {
			if (CollectedEvidences.Count < this._allEvidences.Count) return;
			this._buttonNextScreen.gameObject.SetActive(true);
		}
	}
}
