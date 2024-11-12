using Plugins.Infinity.Base.UI.ViewModels;
using Plugins.Infinity.DI.Binding;

namespace Plugins.Infinity.Base.UI.Views {
	public class BaseAppMenuScreenViewModelBinding : ItemBinding<BaseAppMenuScreenViewModel> {
		public void StartGame () {
			item.StartGame();
		}
	}
}
