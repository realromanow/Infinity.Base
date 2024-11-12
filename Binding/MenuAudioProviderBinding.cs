using Plugins.Infinity.Base.App;
using Plugins.Infinity.DI.Binding;
using UniRx;
using UnityEngine;

namespace Plugins.Infinity.Base.Binding {
	public class MenuAudioProviderBinding : ItemBinding<MenuAudioProvider> {
		[SerializeField]
		private AudioSource _audioSource;

		protected override void RegisterInitialize () {
			base.RegisterInitialize();

			item.playMenuSound
				.Subscribe(_ => _audioSource.UnPause())
				.AddTo(bindingDisposable);
			
			item.pauseMenuSound
				.Subscribe(_ => _audioSource.Pause())
				.AddTo(bindingDisposable);
		}
	}
}
