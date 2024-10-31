using System;
using UniRx;

namespace Infinity.Base.UI.ViewModels {
	public class BaseAppSettingsScreenViewModel : IDisposable {
		public ReactiveCommand disableSoundCommand { get; } = new();
		public ReactiveCommand enableSoundCommand { get; } = new();

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
