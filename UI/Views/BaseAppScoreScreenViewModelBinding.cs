using Infinity.Base.UI.ViewModels;
using Infinity.Player.Models;
using Plugins.Infinity.DI.Binding;
using UnityEngine;

namespace Infinity.Base.UI.Views {
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
