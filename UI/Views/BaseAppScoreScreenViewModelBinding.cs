using Plugins.Infinity.Base.UI.ViewModels;
using Plugins.Infinity.DI.Binding;
using Plugins.Infinity.Player.Models;
using UnityEngine;

namespace Plugins.Infinity.Base.UI.Views {
	public class BaseAppScoreScreenViewModelBinding : ItemBinding<BaseAppScoreScreenViewModel> {
		[SerializeField]
		private GameObject _leaderboardPlayerPrefab;
		
		[SerializeField]
		private Transform _leaderboardPlayerContainer;

		[SerializeField]
		private GameObject _loadingMark;

		protected override void RegisterInitialize () {
			base.RegisterInitialize();
			
			item.onPlayersLoaded += ItemOnPlayersLoaded;
		}

		private void ItemOnPlayersLoaded (LeaderboardPlayerModel[] players) {
			_loadingMark.SetActive(false);
			
			foreach (var playerModel in players) {
				UnityEngine.Object
					.Instantiate(_leaderboardPlayerPrefab, _leaderboardPlayerContainer)
					.GetComponentInChildren<LeaderboardPlayerModelBinding>()
					.SetItem(playerModel, playerModel.displayName);
			}
		}
	}
}
