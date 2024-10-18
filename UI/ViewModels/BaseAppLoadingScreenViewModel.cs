using Infinity.Extensions;
using System;

namespace Infinity.Base.UI.ViewModels {
	public class BaseAppLoadingScreenViewModel : IDisposable {
		public event Action<float> onProgressStatusUpdate;

		public void UpdateProgress (float progress) {
			onProgressStatusUpdate?.Invoke(progress);
		}

		public void Dispose() {
			onProgressStatusUpdate?.RemoveAllListeners();
		}
	}
}
