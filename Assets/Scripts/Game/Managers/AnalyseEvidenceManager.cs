﻿using System;
using System.Linq;
using CDK;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game {
	public class AnalyseEvidenceManager : MonoBehaviour {
		
		private int _evidencesToClick;
		[SerializeField] private Button _buttonFinish;
		[SerializeField] private CSceneField _nextScene;
		[SerializeField] private UnityEvent _completed;

		
		private void Awake() {
			var allPossibleEvidences = this.GetComponentsInChildren<TableEvidenceItem>();
			foreach (var ev in allPossibleEvidences) {
				ev.gameObject.SetActive(false);
			}

			var collectedEvidences = allPossibleEvidences.Where(e => InvestigationManager.CollectedEvidences.Contains(e.EvidenceName.ToLowerInvariant()));
			foreach (var ev in collectedEvidences) {
				ev.Initialize(this, OnClickEvidence);
			}

			this._evidencesToClick = collectedEvidences.Count();
			
			this._buttonFinish.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => {
				GameScenesCarTransition.get.LoadPericiaScene(_nextScene);
			});
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
