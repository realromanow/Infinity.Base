using Plugins.Infinity.Base.Api;
using Plugins.Infinity.Base.UI.Api;
using Plugins.Infinity.Base.UI.ViewModels;
using Plugins.Infinity.Player.Api;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Plugins.Infinity.Base.UI.App {
	public class NavigationScreenService : INavigationScreenService, IDisposable {
		private readonly IBaseAppScreenService _appScreenService;
		private readonly IPlayerProvider _playerProvider;
		private readonly IMenuAudioProvider _menuAudioProvider;
		private readonly CompositeDisposable _compositeDisposable = new();

		public NavigationScreenService (
			IBaseAppScreenService appScreenService,
			IPlayerProvider playerProvider,
			IMenuAudioProvider menuAudioProvider) {
			_appScreenService = appScreenService;
			_playerProvider = playerProvider;
			_menuAudioProvider = menuAudioProvider;
		}

		public void ShowSettingsScreen () {
			_appScreenService.RestoreMenuScreen();

			var settingsVm = new BaseAppSettingsScreenViewModel(_menuAudioProvider.audioIsPlay)
				.AddTo(_compositeDisposable);

			settingsVm.enableSoundCommand
				.Subscribe(_ => {
					_menuAudioProvider.PlayMenuSound();
				})
				.AddTo(_compositeDisposable);
			
			settingsVm.disableSoundCommand
				.Subscribe(_ => {
					_menuAudioProvider.PauseMenuSound();
				})
				.AddTo(_compositeDisposable);
			
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

		public void ShowEnterNameScreen () {
			var viewModel = new BaseAppEnterNameViewModel(PlayerPrefs.GetString("player_name")).AddTo(_compositeDisposable);
			viewModel.nameSubmitCommand
				.Subscribe(_ => {
					PlayerPrefs.SetString("player_name", viewModel.playerName.Value);
					_appScreenService.HideEnterNameScreen();
				})
				.AddTo(_compositeDisposable);
			
			_appScreenService.ShowEnterNameScreen(viewModel);
		}

		private async Task AsyncFillScoreScreen (BaseAppScoreScreenViewModel viewModel) {
			var leaderboard = await _playerProvider.GetLeaderboard(CancellationToken.None);
			viewModel.FillPlayers(leaderboard.players);
		}

		public void Dispose() {
			_compositeDisposable.Dispose();
		}
	}
}
