using Infinity.Base.UI.ViewModels;
using Plugins.Infinity.DI.Binding;

namespace Infinity.Base.UI.Views {
	public class BasePreMatchScreenViewModelBinding : ItemBinding<BasePreMatchScreenViewModel> {
		public void SelectMultiPlayer () {
			item.SelectMultiPlayer();
		}

		public void SelectSinglePlayer () {
			item.SelectSinglePlayer();
		}

		public void SelectBack () {
			item.SelectBack();
		}
	}
}
