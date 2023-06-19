using CDK;
using UnityEngine;

namespace Game {
	public class GameMenu : MonoBehaviour {

		public void QuitGame() {
			CApplication.Quit();
		}
		
	}
}
