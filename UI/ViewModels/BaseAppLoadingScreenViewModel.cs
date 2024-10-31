using System;
using UniRx;

namespace Infinity.Base.UI.ViewModels {
	public class BaseAppLoadingScreenViewModel : IDisposable {
		public IReadOnlyReactiveProperty<float> loadingProgress => _loadingProgress;
		
		private readonly ReactiveProperty<float> _loadingProgress = new(0f);

		public void UpdateProgress (float progress) {
			_loadingProgress.Value = progress;
		}

		public void Dispose() {
			_loadingProgress.Dispose();
		}
	}
}
