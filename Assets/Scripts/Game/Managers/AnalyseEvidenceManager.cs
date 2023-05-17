using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Game {
	public class AnalyseEvidenceManager : MonoBehaviour {
		
		private int _evidencesToClick;
		private UnityEvent _completed;
		
		private void Awake() {
			var allPossibleEvidences = this.GetComponentsInChildren<TableEvidenceItem>();
			foreach (var ev in allPossibleEvidences) {
				ev.gameObject.SetActive(false);
			}

			var collectedEvidences = allPossibleEvidences.Where(e => InvestigationManager.CollectedEvidences.Contains(e.EvidenceName));
			foreach (var ev in collectedEvidences) {
				ev.Initialize(this, OnClickEvidence);
			}

			this._evidencesToClick = collectedEvidences.Count();
		}

		private void OnClickEvidence() {
			this._evidencesToClick -= 1;
			CheckForCompletion();
		}

		private void CheckForCompletion() {
			if (this._evidencesToClick > 0) return;
			_completed?.Invoke();
		}
	}
}
