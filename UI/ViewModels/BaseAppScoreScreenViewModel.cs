using Plugins.Infinity.Extensions;
using Plugins.Infinity.Player.Models;
using System;

namespace Plugins.Infinity.Base.UI.ViewModels {
	public class BaseAppScoreScreenViewModel : IDisposable {
		public event Action<LeaderboardPlayerModel[]> onPlayersLoaded;

		public void FillPlayers (LeaderboardPlayerModel[] players) {
			onPlayersLoaded?.Invoke(players);
		}

		public void Dispose() {
			onPlayersLoaded?.RemoveAllListeners();
		}
	}
}
