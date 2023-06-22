using UnityEngine;

namespace Game {
	public class AudioPlayAndStopper : MonoBehaviour {

		[SerializeField] private AudioClip _audioClip;
		private AudioSource _audioSource;
		[SerializeField] private bool _loop;
		

		
		
		
		private void OnEnable() {
			if (_audioClip == null) return;
			this._audioSource = this.gameObject.AddComponent<AudioSource>();
			this._audioSource.spatialize = false;
			this._audioSource.clip = _audioClip;
			this._audioSource.loop = _loop;
			this._audioSource.Play();
		}

		private void OnDisable() {
			if(this._audioSource) this._audioSource.Stop();
		}
	}
}
