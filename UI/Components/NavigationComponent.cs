using Infinity.Base.UI.Api;
using Plugins.Infinity.DI.Components;

namespace Infinity.Base.UI.Components {
	public class NavigationComponent : BaseMonoInjectComponent {
		private readonly INavigationScreenService _navigationScreenService;

		public void ShowSettingsScreen () {
			_navigationScreenService.ShowSettingsScreen();
		}

		public void ShowAchievesScreen () {
			_navigationScreenService.ShowAchievesScreen();
		}

		public void ShowScoreScreen () {
			_navigationScreenService.ShowScoreScreen();
		}
	}
}
