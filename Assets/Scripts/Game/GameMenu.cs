using System;
using CDK;
using Game.Interrogatorio;
using UnityEngine;

namespace Game {
	public class GameMenu : MonoBehaviour {
		
		private void Awake() {
			DepoimentosManager.ClearAllDepoimentos();
		}

		public void QuitGame() {
			CApplication.Quit();
		}
		
	}
}
