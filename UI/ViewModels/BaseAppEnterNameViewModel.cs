using System;
using UniRx;

namespace Plugins.Infinity.Base.UI.ViewModels {
	public class BaseAppEnterNameViewModel : IDisposable {
		public ReactiveCommand<string> nameSubmitCommand { get; } = new();
		public IReadOnlyReactiveProperty<string> playerName => _playerName;
		
		private readonly ReactiveProperty<string> _playerName;

		public BaseAppEnterNameViewModel (string defaultName) {
			_playerName = new ReactiveProperty<string>(defaultName);
		}

		public void SubmitName () {
			nameSubmitCommand.Execute(_playerName.Value);
		}

		public void Dispose() {
			_playerName.Dispose();
			nameSubmitCommand.Dispose();
		}
	}
}
