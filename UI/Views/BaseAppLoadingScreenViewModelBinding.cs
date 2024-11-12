using Plugins.Infinity.Base.UI.ViewModels;
using Plugins.Infinity.DI.Binding;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Infinity.Base.UI.Views {
	public class BaseAppLoadingScreenViewModelBinding : ItemBinding<BaseAppLoadingScreenViewModel> {
		[SerializeField]
		private Image _progressBar;

		[SerializeField]
		private TextMeshProUGUI _progressLabel;

		protected override void RegisterInitialize () {
			base.RegisterInitialize();

			item.loadingProgress
				.Subscribe(value => {
					_progressBar.fillAmount = value;
					_progressLabel.text = $"{value * 100}%";
				})
				.AddTo(bindingDisposable);
		}

		public void OpenSupportUrl () {
			Application.OpenURL("https://precisionpoundhammerstrong.com/support.html");
		}
	}
}
