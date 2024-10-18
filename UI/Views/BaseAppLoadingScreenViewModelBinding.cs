using Infinity.Base.UI.ViewModels;
using Plugins.Infinity.DI.Binding;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infinity.Base.UI.Views {
	public class BaseAppLoadingScreenViewModelBinding : ItemBinding<BaseAppLoadingScreenViewModel> {
		[SerializeField]
		private Image _progressBar;

		[SerializeField]
		private TextMeshProUGUI _progressLabel;

		protected override void RegisterInitialize () {
			base.RegisterInitialize();
			
			item.onProgressStatusUpdate += ItemOnProgressStatusUpdate;
		}

		public void OpenSupportUrl () {
			Application.OpenURL("https://theriftwithineternalshift.com/support.html");
		}
		
		private void ItemOnProgressStatusUpdate (float progress) {
			_progressBar.fillAmount = progress;
			_progressLabel.text = $"{progress * 100}%";
		}
	}
}
