using System;
using UniRx;

namespace Plugins.Infinity.Base.UI.ViewModels {
	public class BaseAppMenuScreenViewModel : IDisposable {
		public ReactiveCommand startCommand { get; } = new();

		public void StartGame () {
			startCommand.Execute();
		}

		public void Dispose() {
			startCommand.Dispose();
		}
	}
}
