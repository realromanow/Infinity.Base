using Infinity.Base.UI.Api;
using Infinity.Base.UI.ViewModels;
using Plugins.Infinity.UI.Api;
using System;
using UnityEngine;

namespace Infinity.Base.UI.App {
	public class BaseAppScreenService : IBaseAppScreenService {
		private readonly IInfinityUIService _infinityUIService;
		private readonly Preferences _preferences;
		private readonly Canvas _baseCanvas;

		public BaseAppScreenService (
			IInfinityUIService infinityUIService,
			Preferences preferences) {
			_infinityUIService = infinityUIService;
			_preferences = preferences;

			_baseCanvas = UnityEngine.Object.Instantiate(_preferences.baseCanvasPrefab);
		}

		public void RestoreMenuScreen () {
			_infinityUIService.RemoveAllExceptVariant(_preferences.menuScreenPrefab, _baseCanvas);
		}

		public void ShowMenuScreen (BaseAppMenuScreenViewModel viewModel) {
			_infinityUIService.SetupInterfaceVariant(_preferences.menuScreenPrefab, _baseCanvas, viewModel);
		}

		public void HideMenuScreen () {
			_infinityUIService.RemoveInterfaceVariant(_preferences.menuScreenPrefab, _baseCanvas);
		}

		public void ShowSettingsScreen (BaseAppSettingsScreenViewModel viewModel) {
			_infinityUIService.SetupInterfaceVariant(_preferences.settingsScreenPrefab, _baseCanvas, viewModel);
		}

		public void HideSettingsScreen () {
			_infinityUIService.RemoveInterfaceVariant(_preferences.settingsScreenPrefab, _baseCanvas);
		}

		public void ShowAchievesScreen (BaseAppAchievesScreenViewModel viewModel) {
			_infinityUIService.SetupInterfaceVariant(_preferences.achievementsScreenPrefab, _baseCanvas, viewModel);
		}

		public void HideAchievesScreen () {
			_infinityUIService.RemoveInterfaceVariant(_preferences.achievementsScreenPrefab, _baseCanvas);
		}

		public void ShowScoreScreen (BaseAppScoreScreenViewModel viewModel) {
			_infinityUIService.SetupInterfaceVariant(_preferences.scoreboardScreenPrefab, _baseCanvas, viewModel);
		}

		public void HideScoreScreen () {
			_infinityUIService.RemoveInterfaceVariant(_preferences.scoreboardScreenPrefab, _baseCanvas);
		}

		public void ShowLoadingScreen (BaseAppLoadingScreenViewModel viewModel) {
			_infinityUIService.SetupInterfaceVariant(_preferences.loginScreenPrefab, _baseCanvas, viewModel);
		}

		public void HideLoadingScreen () {
			_infinityUIService.RemoveInterfaceVariant(_preferences.loginScreenPrefab, _baseCanvas);
		}

		public void ShowEnterNameScreen (BaseAppEnterNameViewModel viewModel) {
			_infinityUIService.SetupInterfaceVariant(_preferences.enterNameScreenPrefab, _baseCanvas, viewModel);
		}

		public void HideEnterNameScreen () {
			_infinityUIService.RemoveInterfaceVariant(_preferences.enterNameScreenPrefab, _baseCanvas);
		}

		public void ShowPreMatchScreen (BasePreMatchScreenViewModel viewModel) {
			_infinityUIService.SetupInterfaceVariant(_preferences.preMatchScreenPrefab, _baseCanvas, viewModel);
		}

		public void HidePreMatchScreen () {
			_infinityUIService.RemoveInterfaceVariant(_preferences.preMatchScreenPrefab, _baseCanvas);
		}

		[Serializable]
		public class Preferences {
			[SerializeField]
			private Canvas _baseCanvasPrefab;

			[SerializeField]
			private GameObject _menuScreenPrefab;
			
			[SerializeField]
			private GameObject _settingsScreenPrefab;
			
			[SerializeField]
			private GameObject _achievementsScreenPrefab;
			
			[SerializeField]
			private GameObject _scoreboardScreenPrefab;
			
			[SerializeField]
			private GameObject _loginScreenPrefab;

			[SerializeField]
			private GameObject _enterNameScreenPrefab;
			
			[SerializeField]
			private GameObject _preMatchScreenPrefab;

			public Canvas baseCanvasPrefab => _baseCanvasPrefab;
			public GameObject menuScreenPrefab => _menuScreenPrefab;
			public GameObject settingsScreenPrefab => _settingsScreenPrefab;
			public GameObject achievementsScreenPrefab => _achievementsScreenPrefab;
			public GameObject scoreboardScreenPrefab => _scoreboardScreenPrefab;
			public GameObject loginScreenPrefab => _loginScreenPrefab;
			public GameObject enterNameScreenPrefab => _enterNameScreenPrefab;
			public GameObject preMatchScreenPrefab => _preMatchScreenPrefab;
		}
	}
}
