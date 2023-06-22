using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	
	[RequireComponent(typeof(Button))]
	public class ButtonSound : MonoBehaviour {

		[SerializeField] private ButtonSoundData _soundData;
		private AudioSource _audioSource;
		private Button _button;


		private void Awake() {
			this._audioSource = this.gameObject.AddComponent<AudioSource>();
			_button = this.GetComponent<Button>();
		}

		private void OnEnable() {
			_button.OnClickAsObservable().TakeUntilDisable(this).Subscribe(_ => {
				this._audioSource.clip = _soundData.ButtonSound;
				this._audioSource.volume = _soundData.ButtonSoundVolume;
				this._audioSource.Play();
			});
		}
	}
}
