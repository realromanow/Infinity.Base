using Infinity.Base.Api;
using Infinity.Base.UI.Api;
using Infinity.Base.UI.ViewModels;
using Infinity.Player.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infinity.Base.App {
	public class GameProvider : IGameProvider, IDisposable {
		private readonly IBaseAppScreenService _appScreenService;
		private readonly IPlayerProvider _playerProvider;
		private readonly IList<IDisposable> _disposables = new List<IDisposable>();

		public GameProvider (
			IBaseAppScreenService appScreenService,
			IPlayerProvider playerProvider) {
			_appScreenService = appScreenService;
			_playerProvider = playerProvider;
		}

		public async Task StartProvideApplication () {
			var loadingViewModel = new BaseAppLoadingScreenViewModel();
			_appScreenService.ShowLoadingScreen(loadingViewModel);

			var progress = new Progress<float>(x => { loadingViewModel.UpdateProgress(x); });

			var player = await _playerProvider.GetPlayer(CancellationToken.None, progress);
			_appScreenService.HideLoadingScreen();

			var menuViewModel = new BaseAppMenuScreenViewModel();

			_disposables.Add(menuViewModel);
			menuViewModel.onStartGamePressed += () => MenuViewModelOnStartGamePressed(player.displayName);
			
			_appScreenService.ShowMenuScreen(menuViewModel);
		}

		private void MenuViewModelOnStartGamePressed (string playerName) {
			var enterNameViewModel = new BaseAppEnterNameViewModel(playerName);
			
			_disposables.Add(enterNameViewModel);
			enterNameViewModel.onNameSubmitted += EnterNameViewModelOnNameSubmitted;

			_appScreenService.ShowEnterNameScreen(enterNameViewModel);
		}

		private void EnterNameViewModelOnNameSubmitted () {
			_appScreenService.HideEnterNameScreen();
			
			var preMatchScreenViewModel = new BasePreMatchScreenViewModel();
			_disposables.Add(preMatchScreenViewModel);

			preMatchScreenViewModel.onMultiPlayerSelected += LaunchGameplay;
			preMatchScreenViewModel.onSinglePlayerSelected += LaunchGameplay;
			preMatchScreenViewModel.onBackSelected += _appScreenService.HidePreMatchScreen;
			
			_appScreenService.ShowPreMatchScreen(preMatchScreenViewModel);
		}

		private void LaunchGameplay () {
			_appScreenService.HidePreMatchScreen();
			_appScreenService.HideMenuScreen();
			
			CoroutineRunner.instance.StartCoroutine(LaunchEnumerator());
		}

		private IEnumerator LaunchEnumerator () {
			var loadingVm = new BaseAppLoadingScreenViewModel();
			_disposables.Add(loadingVm);
			_appScreenService.ShowLoadingScreen(loadingVm);
			
			IProgress<float> progress = new Progress<float>(x => { loadingVm.UpdateProgress(x); });
			progress.Report(0.3f);

			yield return new WaitForSeconds(2f);

			SceneManager.LoadScene("GameplayScene");
		}

		public void Dispose() {
			foreach (var disposable in _disposables) {
				disposable.Dispose();
			}
		}
	}
}
