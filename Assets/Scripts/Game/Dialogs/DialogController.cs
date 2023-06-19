using System;
using CDK;
using Game.Dialogs;
using Game.Enums;
using UnityEngine;

namespace Game {
	public class DialogController : MonoBehaviour {
		
		[SerializeField] private CSceneField _nextScene;
		[SerializeField] private string _carMessage;
		
		[Header("O valor do campo abaixo nao eh mais usado, foi mantido pra referencia do campo 'Car message'"), SerializeField, Obsolete] private NextSceneType _nextSceneType;

		private Dialog[] AllDialogs;

		
		
		
		private void Awake() {
			AllDialogs = this.GetComponentsInChildren<Dialog>(true);
			foreach (var d in AllDialogs) {
				d.gameObject.SetActive(false);
			}
			AllDialogs[0].gameObject.SetActive(true);
		}

		public void NextDialog() {
			for (int i = 0; i < AllDialogs.Length; i++) {
				if (!AllDialogs[i].isActiveAndEnabled) continue;
				if (i + 1 >= AllDialogs.Length) {
					DialogsEnded();
					return;
				}
				AllDialogs[i].gameObject.SetActive(false);
				AllDialogs[i + 1].ShowDialog();
				return;
			}
		}


		private void DialogsEnded() {
			GameScenesCarTransition.get.LoadCarScene(this._carMessage, _nextScene);
		}
		
	}
}
