using Infinity.Extensions;
using System;

namespace Infinity.Base.UI.ViewModels {
	public class BaseAppMenuScreenViewModel : IDisposable {
		public event Action onStartGamePressed; 
		
		public void StartGame () {
			onStartGamePressed?.Invoke();
		}

		public void Dispose() {
			onStartGamePressed?.RemoveAllListeners();
		}
	}
}
