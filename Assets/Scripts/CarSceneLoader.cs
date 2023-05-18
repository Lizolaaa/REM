using CDK;
using UnityEngine;

namespace Game {
	public class CarSceneLoader : MonoBehaviour{

		[SerializeField] private CSceneField _nextScene;

		
		
		
		public void LoadPericiaScene() {
			GameScenesCarTransition.get.LoadPericiaScene(this._nextScene);
		}
		
		public void LoadCrimeScene() {
			GameScenesCarTransition.get.LoadCrimeScene(this._nextScene);
		}
		
	}
}
