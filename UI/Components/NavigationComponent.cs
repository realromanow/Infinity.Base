using Plugins.Infinity.Base.UI.Api;
using Plugins.Infinity.DI.Components;

namespace Plugins.Infinity.Base.UI.Components {
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

		public void ShowEnterNameScreen () {
			_navigationScreenService.ShowEnterNameScreen();
		}
	}
}
