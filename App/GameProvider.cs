using Cysharp.Threading.Tasks;
using Infinity.Base.Api;
using Infinity.Base.UI.Api;
using Infinity.Base.UI.ViewModels;
using Infinity.Player.Api;
using System;
using System.Threading;
using UniRx;
using UnityEngine.SceneManagement;

namespace Infinity.Base.App {
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

			var menuViewModel = new BaseAppMenuScreenViewModel()
				.AddTo(_compositeDisposable);
			
			menuViewModel.startCommand
				.Subscribe(_ => MenuViewModelOnStartGamePressed(player.displayName))
				.AddTo(_compositeDisposable);
			
			_appScreenService.ShowMenuScreen(menuViewModel);
		}

		private void MenuViewModelOnStartGamePressed (string playerName) {
			var enterNameViewModel = new BaseAppEnterNameViewModel(playerName)
				.AddTo(_compositeDisposable);
			
			enterNameViewModel.nameSubmitCommand
				.Subscribe(_ => EnterNameViewModelOnNameSubmitted())
				.AddTo(_compositeDisposable);

			_appScreenService.ShowEnterNameScreen(enterNameViewModel);
		}

		private void EnterNameViewModelOnNameSubmitted () {
			_appScreenService.HideEnterNameScreen();
			
			var preMatchScreenViewModel = new BasePreMatchScreenViewModel()
				.AddTo(_compositeDisposable);

			preMatchScreenViewModel.goBackCommand
				.Subscribe(_ => _appScreenService.HidePreMatchScreen())
				.AddTo(_compositeDisposable);
			
			preMatchScreenViewModel.multiPlayerCommand
				.Subscribe(_ => LaunchGameplay(_cancellationTokenSource.Token).Forget())
				.AddTo(_compositeDisposable);
			
			preMatchScreenViewModel.singlePlayerCommand
				.Subscribe(_ => LaunchGameplay(_cancellationTokenSource.Token).Forget())
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

		public void Dispose() {
			_cancellationTokenSource.Cancel();
			
			_compositeDisposable.Dispose();
			_cancellationTokenSource.Dispose();
		}
	}
}
