using Infinity.Base.UI.Components;
using Infinity.Base.UI.ViewModels;
using Plugins.Infinity.DI.Binding;
using UnityEngine;

namespace Infinity.Base.UI.Views {
	public class BaseAppSettingsScreenViewModelBinding : ItemBinding<BaseAppSettingsScreenViewModel> {
		[SerializeField]
		private ButtonThemeSwitcherComponent _soundButton;

		public void SwitchSound () {
			if (_soundButton.isActiveState) {
				item.DisableSound();
			}
			else {
				item.EnableSound();
			}
			
			_soundButton.SwitchTheme();
		}
	}
}
