using Plugins.Infinity.Player.Models;
using System;
using UniRx;

namespace Plugins.Infinity.Base.UI.ViewModels {
	public class BaseAppAchievesScreenViewModel : IDisposable {
		public ReactiveCommand<AchievementModel[]> achievesLoadedCommand { get; } = new();

		public void FillAchieves (AchievementModel[] achieves) {
			achievesLoadedCommand.Execute(achieves);
		}
		
		public void Dispose() {
			achievesLoadedCommand.Dispose();
		}
	}
}
