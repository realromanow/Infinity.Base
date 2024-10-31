using System;
using UniRx;

namespace Infinity.Base.UI.ViewModels {
	public class BasePreMatchScreenViewModel : IDisposable {
		public ReactiveCommand multiPlayerCommand { get; } = new();
		public ReactiveCommand singlePlayerCommand { get; } = new();
		public ReactiveCommand goBackCommand { get; } = new();

		public void SelectMultiPlayer () {
			multiPlayerCommand.Execute();
		}

		public void SelectSinglePlayer () {
			singlePlayerCommand.Execute();
		}

		public void SelectBack () {
			goBackCommand.Execute();
		}

		public void Dispose() {
			multiPlayerCommand.Dispose();
			singlePlayerCommand.Dispose();
			goBackCommand.Dispose();
		}
	}
}
