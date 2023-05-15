using System;
using CDK;
using Game.Dialogs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game {
	public class DialogController : MonoBehaviour {

		[SerializeField] private CSceneField _sceneOnDialogsEnd;
		
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
			SceneManager.LoadScene(_sceneOnDialogsEnd);
		}
		
	}
}
