using Plugins.Infinity.Base.UI.ViewModels;
using Plugins.Infinity.DI.Binding;

namespace Plugins.Infinity.Base.UI.Views {
	public class BasePreMatchScreenViewModelBinding : ItemBinding<BasePreMatchScreenViewModel> {
		public void SelectLocale () {
			item.SelectLocalOpponent();
		}

		public void SelectBot () {
			item.SelectLocalBot();
		}

		public void SelectOnline () {
			item.SelectOnlineOpponent();
		}
	}
}
