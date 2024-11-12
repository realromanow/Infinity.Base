using UniRx;

namespace Plugins.Infinity.Base.Api {
	public interface IMenuAudioProvider {
		public bool audioIsPlay { get; }
		ReactiveCommand playMenuSound { get; }
		ReactiveCommand pauseMenuSound { get; }

		public void PlayMenuSound ();

		public void PauseMenuSound ();
	}
}
