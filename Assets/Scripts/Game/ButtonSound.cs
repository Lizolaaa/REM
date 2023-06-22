using CDK;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	
	[RequireComponent(typeof(Button))]
	public class ButtonSound : MonoBehaviour {

		[SerializeField] private ButtonSoundData _soundData;
		private Button _button;


		
		
		private void Awake() {
			_button = this.GetComponent<Button>();
			_button.OnClickAsObservable().Subscribe(_ => {
				CSoundManager.get.PlayOneShot(_soundData.ButtonSound, _soundData.ButtonSoundVolume);
			});
		}
		
	}
}
