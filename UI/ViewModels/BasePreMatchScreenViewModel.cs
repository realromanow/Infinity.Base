using Infinity.Extensions;
using System;

namespace Infinity.Base.UI.ViewModels {
	public class BasePreMatchScreenViewModel : IDisposable {
		public event Action onMultiPlayerSelected;
		public event Action onSinglePlayerSelected;
		public event Action onBackSelected;

		public void SelectMultiPlayer () {
			onMultiPlayerSelected?.Invoke();
		}

		public void SelectSinglePlayer () {
			onSinglePlayerSelected?.Invoke();
		}

		public void SelectBack () {
			onBackSelected?.Invoke();
		}

		public void Dispose() {
			onMultiPlayerSelected?.RemoveAllListeners();
			onSinglePlayerSelected?.RemoveAllListeners();
			onBackSelected?.RemoveAllListeners();
		}
	}
}
