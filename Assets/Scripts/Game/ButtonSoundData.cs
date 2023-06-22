using UnityEngine;

namespace Game {
	public class ButtonSoundData : ScriptableObject {

		public AudioClip ButtonSound;
		[Range(0f,1f)]public float ButtonSoundVolume = 1f;


	}
}
