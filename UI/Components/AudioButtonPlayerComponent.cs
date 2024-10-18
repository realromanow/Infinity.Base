using UnityEngine;
using UnityEngine.UI;

namespace Infinity.Base.UI.Components {
	[RequireComponent(typeof(AudioSource))]
	public class AudioButtonPlayerComponent : MonoBehaviour {
		private AudioSource _audioSource;
		
		[SerializeField]
		private AudioClip _audioClip;

		private void Awake () {
			_audioSource = GetComponent<AudioSource>();
			GetComponent<Button>().onClick.AddListener(PlaySound);
		}

		private void PlaySound () {
			_audioSource.PlayOneShot(_audioClip);
		}
	}
}
