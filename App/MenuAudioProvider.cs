using Plugins.Infinity.Base.Api;
using System;
using UniRx;

namespace Plugins.Infinity.Base.App {
	public class MenuAudioProvider : IMenuAudioProvider, IDisposable {
		public bool audioIsPlay { get; private set; }
		public ReactiveCommand playMenuSound { get; } = new();
		public ReactiveCommand pauseMenuSound { get; } = new();

		public void PlayMenuSound () {
			playMenuSound.Execute();
			audioIsPlay = true;
		}

		public void PauseMenuSound () {
			pauseMenuSound.Execute();
			audioIsPlay = false;
		}

		public void Dispose () {
			playMenuSound?.Dispose();
			pauseMenuSound?.Dispose();
		}
	}
}
