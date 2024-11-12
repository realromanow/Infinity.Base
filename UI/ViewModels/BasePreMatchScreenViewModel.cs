using System;
using UniRx;

namespace Plugins.Infinity.Base.UI.ViewModels {
	public class BasePreMatchScreenViewModel : IDisposable {
		public ReactiveCommand localOpponentCommand { get; } = new();
		public ReactiveCommand localBotCommand { get; } = new();
		public ReactiveCommand onlineOpponentCommand { get; } = new();

		public void SelectLocalOpponent () {
			localOpponentCommand.Execute();
		}

		public void SelectLocalBot () {
			localBotCommand.Execute();
		}

		public void SelectOnlineOpponent () {
			onlineOpponentCommand.Execute();
		}

		public void Dispose() {
			localOpponentCommand.Dispose();
			localBotCommand.Dispose();
			onlineOpponentCommand.Dispose();
		}
	}
}
