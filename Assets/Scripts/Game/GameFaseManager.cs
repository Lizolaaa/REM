using UnityEngine;
using UnityEngine.Events;

namespace Game {
	public class GameFaseManager : MonoBehaviour {

		[SerializeField] private int _stepsToComplete = 4;
		private int _currentStep;
		[SerializeField] private UnityEvent _onStepsCompleted;
		
		
		

		private void Awake() {
			this._currentStep = 0;
		}

		private void CheckForStepCompletion() {
			if (this._currentStep < this._stepsToComplete) return;
			this._onStepsCompleted?.Invoke();
		}
		
		
		public void AddStep() {
			this._currentStep += 1;
			CheckForStepCompletion();
		}
	}
}
