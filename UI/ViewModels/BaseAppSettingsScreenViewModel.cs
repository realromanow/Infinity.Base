using System;
using UniRx;

namespace Plugins.Infinity.Base.UI.ViewModels {
	public class BaseAppSettingsScreenViewModel : IDisposable {
		public ReactiveCommand disableSoundCommand { get; } = new();
		public ReactiveCommand enableSoundCommand { get; } = new();
		public bool initAudioStatus { get; }

		public BaseAppSettingsScreenViewModel (bool initAudioStatus) {
			this.initAudioStatus = initAudioStatus;
		}

		public void EnableSound () {
			enableSoundCommand.Execute();
		}

		public void DisableSound () {
			disableSoundCommand.Execute();
		}

		public void Dispose () {
			disableSoundCommand?.Dispose();
			enableSoundCommand?.Dispose();
		}
	}
}
