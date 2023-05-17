using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class TableEvidenceItem : MonoBehaviour {
		
		public string EvidenceName;
		[SerializeField] private GameObject _screenToShow;
		[SerializeField] private Button _buttonShowScreen;
		private AnalyseEvidenceManager manager;
		private Action onClickEvidence;

		public void Initialize(AnalyseEvidenceManager manager, Action onClickEvidence) {
			this.manager = manager;
			this.onClickEvidence = onClickEvidence;
			gameObject.SetActive(true);
		}
		
		private void Awake() {
			this._buttonShowScreen.OnClickAsObservable().TakeUntilDestroy(this).Subscribe(_ => {
				this._screenToShow.gameObject.SetActive(true);
				onClickEvidence?.Invoke();
			});
		}

	}
}
