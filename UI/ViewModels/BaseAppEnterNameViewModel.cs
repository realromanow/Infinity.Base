using Infinity.Extensions;
using System;

namespace Infinity.Base.UI.ViewModels {
	public class BaseAppEnterNameViewModel : IDisposable {
		public event Action onNameSubmitted;
		public string defaultName { get; }

		public BaseAppEnterNameViewModel (string defaultName) {
			this.defaultName = defaultName;
		}

		public void SubmitName () {
			onNameSubmitted?.Invoke();
		}

		public void Dispose() {
			onNameSubmitted?.RemoveAllListeners();
		}
	}
}
