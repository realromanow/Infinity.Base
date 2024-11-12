using Plugins.Infinity.Base.UI.ViewModels;
using Plugins.Infinity.DI.Binding;
using Plugins.Infinity.Player.Models;
using UniRx;
using UnityEngine;

namespace Plugins.Infinity.Base.UI.Views {
	public class BaseAppAchievesScreenViewModelBinding : ItemBinding<BaseAppAchievesScreenViewModel> {
		[SerializeField]
		private GameObject _achievementsPrefab;
		
		[SerializeField]
		private Transform _achievementsParent;

		[SerializeField]
		private GameObject _loadingMarker;

		protected override void RegisterInitialize () {
			base.RegisterInitialize();

			item.achievesLoadedCommand
				.Subscribe(ItemOnAchievesLoaded)
				.AddTo(bindingDisposable);
		}

		private void ItemOnAchievesLoaded (AchievementModel[] achieves) {
			// foreach (var achieve in achieves) {
			// 	UnityEngine.Object
			// 		.Instantiate(_achievementsPrefab, _achievementsParent)
			// 		.GetComponentInChildren<AchievementBinding>()
			// 		.SetItem(achieve, achieve.id);
			// }
			
			_loadingMarker.SetActive(false);
		}
	}
}
