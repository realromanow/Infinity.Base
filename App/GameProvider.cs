using Cysharp.Threading.Tasks;
using Plugins.Infinity.Base.Api;
using Plugins.Infinity.Base.UI.Api;
using Plugins.Infinity.Base.UI.ViewModels;
using Plugins.Infinity.Player.Api;
using System;
using System.Threading;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Plugins.Infinity.Base.App {
	public class GameProvider : IGameProvider, IDisposable {
		private readonly IBaseAppScreenService _appScreenService;
		private readonly IPlayerProvider _playerProvider;
		private readonly CompositeDisposable _compositeDisposable = new();
		private readonly CancellationTokenSource _cancellationTokenSource = new();

		public GameProvider (
			IBaseAppScreenService appScreenService,
			IPlayerProvider playerProvider) {
			_appScreenService = appScreenService;
			_playerProvider = playerProvider;
		}

		public async UniTask StartProvideApplication () {
			var loadingViewModel = new BaseAppLoadingScreenViewModel().AddTo(_compositeDisposable);
			_appScreenService.ShowLoadingScreen(loadingViewModel);

			var progress = new Progress<float>(x => { loadingViewModel.UpdateProgress(x); });

			var player = await _playerProvider.GetPlayer(_cancellationTokenSource.Token, progress);
			_appScreenService.HideLoadingScreen();

			var playerName = PlayerPrefs.GetString("player_name");
			if (string.IsNullOrEmpty(playerName)) {
				ShowEnterNameScreen(player.displayName, name => {
					PlayerPrefs.SetString("player_name", name);
					_appScreenService.HideEnterNameScreen();
					ShowMenuScreen();
				});
				return;
			}

			ShowMenuScreen();
		}

		private void ShowMenuScreen () {
			var menuViewModel = new BaseAppMenuScreenViewModel()
				.AddTo(_compositeDisposable);

			menuViewModel.startCommand
				.Subscribe(_ => ShowPreMatchScreen())
				.AddTo(_compositeDisposable);

			_appScreenService.ShowMenuScreen(menuViewModel);
		}

		private void ShowEnterNameScreen (string playerName, Action<string> onNameSubmitted) {
			var enterNameViewModel = new BaseAppEnterNameViewModel(playerName)
				.AddTo(_compositeDisposable);

			enterNameViewModel.nameSubmitCommand
				.Subscribe(onNameSubmitted)
				.AddTo(_compositeDisposable);

			_appScreenService.ShowEnterNameScreen(enterNameViewModel);
		}

		private void ShowPreMatchScreen () {
			var preMatchScreenViewModel = new BasePreMatchScreenViewModel()
				.AddTo(_compositeDisposable);

			preMatchScreenViewModel.onlineOpponentCommand
				.Subscribe(_ => {
					PlayerPrefs.SetString("play_mode", "online");
					LaunchGameplay(_cancellationTokenSource.Token).Forget();
				})
				.AddTo(_compositeDisposable);

			preMatchScreenViewModel.localOpponentCommand
				.Subscribe(_ => {
					PlayerPrefs.SetString("play_mode", "locale");
					LaunchGameplay(_cancellationTokenSource.Token).Forget();
				})
				.AddTo(_compositeDisposable);

			preMatchScreenViewModel.localBotCommand
				.Subscribe(_ => {
					PlayerPrefs.SetString("play_mode", "bot");
					LaunchGameplay(_cancellationTokenSource.Token).Forget();
				})
				.AddTo(_compositeDisposable);

			_appScreenService.ShowPreMatchScreen(preMatchScreenViewModel);
		}

		private async UniTask LaunchGameplay (CancellationToken cancellationToken) {
			_appScreenService.HidePreMatchScreen();
			_appScreenService.HideMenuScreen();

			var loadingVm = new BaseAppLoadingScreenViewModel().AddTo(_compositeDisposable);
			_appScreenService.ShowLoadingScreen(loadingVm);

			IProgress<float> progress = new Progress<float>(x => { loadingVm.UpdateProgress(x); });
			progress.Report(0.3f);

			await UniTask.Delay(1000, cancellationToken: cancellationToken);

			SceneManager.LoadScene("GameplayScene");
		}

		public void Dispose () {
			_cancellationTokenSource.Cancel();

			_compositeDisposable.Dispose();
			_cancellationTokenSource.Dispose();
		}
	}
}
