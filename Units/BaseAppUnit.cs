using Cysharp.Threading.Tasks;
using Plugins.Infinity.Base.App;
using Plugins.Infinity.Base.Binding;
using Plugins.Infinity.Base.UI.App;
using Plugins.Infinity.DI.App;
using Plugins.Infinity.DI.Units;
using UnityEngine;

namespace Plugins.Infinity.Base.Units {
	[CreateAssetMenu(menuName = "Infinity/Units/BaseAppUnit", fileName = "BaseAppUnit")]
	public class BaseAppUnit : AppUnit {
		[SerializeField]
		private BaseAppScreenService.Preferences _screensPreferences;

		[SerializeField]
		private MenuAudioProviderBinding _menuAudioProviderPrefab;

		public override void SetupUnit (AppComponentsRegistry componentsRegistry) {
			base.SetupUnit(componentsRegistry);

			BindAudio(componentsRegistry);

			componentsRegistry.Instantiate<BaseAppScreenService>(_screensPreferences);
			componentsRegistry.Instantiate<NavigationScreenService>();

			componentsRegistry
				.Instantiate<GameProvider>()
				.StartProvideApplication()
				.Forget();
		}

		private void BindAudio (AppComponentsRegistry componentsRegistry) {
			var audioProvider = componentsRegistry.Instantiate<MenuAudioProvider>();
			Instantiate(_menuAudioProviderPrefab)
				.SetItem(audioProvider, audioProvider.GetHashCode().ToString());
		}
	}
}
