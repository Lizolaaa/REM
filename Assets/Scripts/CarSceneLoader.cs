using CDK;
using UnityEngine;

namespace Game {
	public class CarSceneLoader : MonoBehaviour{

		[SerializeField] private CSceneField _nextScene;
		[SerializeField] private string _carMessage;
		

		
		
		public void LoadPericiaScene() {
			GameScenesCarTransition.get.LoadCarScene(_carMessage, this._nextScene);
		}
		
		public void LoadCrimeScene() {
			GameScenesCarTransition.get.LoadCarScene(_carMessage, this._nextScene);
		}
		
	}
}
