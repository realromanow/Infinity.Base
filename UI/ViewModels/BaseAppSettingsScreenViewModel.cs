using Infinity.Extensions;
using System;

namespace Infinity.Base.UI.ViewModels {
	public class BaseAppSettingsScreenViewModel : IDisposable {
		public event Action onDisableSound;
		public event Action onEnableSound;

		public void EnableSound () {
			onEnableSound?.Invoke();
		}

		public void DisableSound () {
			onDisableSound?.Invoke();
		}
		
		public void Dispose() {
			onDisableSound?.RemoveAllListeners();
			onEnableSound?.RemoveAllListeners();
		}
	}
}
