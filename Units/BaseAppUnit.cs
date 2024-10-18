using Infinity.Base.App;
using Infinity.Base.UI.App;
using Plugins.Infinity.DI.App;
using Plugins.Infinity.DI.Units;
using UnityEngine;

namespace Infinity.Base.Units {
	[CreateAssetMenu(menuName = "Infinity/Units/BaseAppUnit", fileName = "BaseAppUnit")]
	public class BaseAppUnit : AppUnit {
		[SerializeField]
		private BaseAppScreenService.Preferences _screensPreferences;

		public override void SetupUnit (AppComponentsRegistry componentsRegistry) {
			base.SetupUnit(componentsRegistry);

			componentsRegistry.Instantiate<BaseAppScreenService>(_screensPreferences);
			componentsRegistry.Instantiate<NavigationScreenService>();
			
			_ = componentsRegistry
				.Instantiate<GameProvider>()
				.StartProvideApplication();
		}
	}
}
