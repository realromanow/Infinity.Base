using Infinity.Audio.Api;
using Infinity.Base.UI.Api;
using Infinity.Base.UI.ViewModels;
using Infinity.Player.Api;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infinity.Base.UI.App {
	public class NavigationScreenService : INavigationScreenService, IDisposable {
		private readonly IBaseAppScreenService _appScreenService;
		private readonly IPlayerProvider _playerProvider;
		private readonly IInfinitySoundService _soundService;
		private readonly List<IDisposable> _disposables = new();

		public NavigationScreenService (
			IBaseAppScreenService appScreenService,
			IPlayerProvider playerProvider, 
			IInfinitySoundService soundService) {
			_appScreenService = appScreenService;
			_playerProvider = playerProvider;
			_soundService = soundService;
		}

		public void ShowSettingsScreen () {
			_appScreenService.RestoreMenuScreen();

			var settingsVm = new BaseAppSettingsScreenViewModel();
			_disposables.Add(settingsVm);

			settingsVm.onEnableSound += _soundService.UnPauseBgSource;
			settingsVm.onDisableSound += _soundService.PauseBgSource;
			
			_appScreenService.ShowSettingsScreen(settingsVm);
		}

		public void ShowAchievesScreen () {
			_appScreenService.RestoreMenuScreen();

			var viewModel = new BaseAppAchievesScreenViewModel();
			_appScreenService.ShowAchievesScreen(viewModel);

			_ = AsyncFillAchievesScreen(viewModel);
		}

		private async Task AsyncFillAchievesScreen (BaseAppAchievesScreenViewModel viewModel) {
			var achieves = await _playerProvider.GetAchievements(CancellationToken.None);
			viewModel.FillAchieves(achieves);
		}

		public void ShowScoreScreen () {
			_appScreenService.RestoreMenuScreen();
			
			var viewModel = new BaseAppScoreScreenViewModel();
			_appScreenService.ShowScoreScreen(viewModel);
			
			_ = AsyncFillScoreScreen(viewModel);
		}

		private async Task AsyncFillScoreScreen (BaseAppScoreScreenViewModel viewModel) {
			var leaderboard = await _playerProvider.GetLeaderboard(CancellationToken.None);
			viewModel.FillPlayers(leaderboard.players);
		}

		public void Dispose() {
			foreach (var disposable in _disposables) {
				disposable.Dispose();
			}
		}
	}
}
