using Infinity.Extensions;
using Infinity.Player.Models;
using System;

namespace Infinity.Base.UI.ViewModels {
	public class BaseAppAchievesScreenViewModel : IDisposable {
		public event Action<AchievementModel[]> onAchievesLoaded;

		public void FillAchieves (AchievementModel[] achieves) {
			onAchievesLoaded?.Invoke(achieves);
		}
		
		public void Dispose() {
			onAchievesLoaded?.RemoveAllListeners();
		}
	}
}
