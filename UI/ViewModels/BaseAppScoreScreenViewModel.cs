using Infinity.Extensions;
using Infinity.Player.Models;
using System;

namespace Infinity.Base.UI.ViewModels {
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
