using Plugins.Infinity.Base.UI.ViewModels;
using Plugins.Infinity.DI.Binding;
using Plugins.Infinity.UI.Components;
using UnityEngine;

namespace Plugins.Infinity.Base.UI.Views {
	public class BaseAppSettingsScreenViewModelBinding : ItemBinding<BaseAppSettingsScreenViewModel> {
		[SerializeField]
		private ButtonThemeSwitcherComponent _soundButton;

		protected override void RegisterInitialize () {
			base.RegisterInitialize();

			_soundButton.Init();
		}

		public void SwitchSound () {
			if (_soundButton.isActiveState) {
				item.DisableSound();
				PlayerPrefs.SetInt("Sound", 0);
			}
			else {
				item.EnableSound();
				PlayerPrefs.SetInt("Sound", 1);
			}
			
			_soundButton.SwitchTheme();
		}
	}
}
