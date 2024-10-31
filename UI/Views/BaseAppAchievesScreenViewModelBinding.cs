using Infinity.Base.UI.ViewModels;
using Infinity.Player.Models;
using Plugins.Infinity.DI.Binding;
using UniRx;
using UnityEngine;

namespace Infinity.Base.UI.Views {
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
			foreach (var achieve in achieves) {
				UnityEngine.Object
					.Instantiate(_achievementsPrefab, _achievementsParent)
					.GetComponentInChildren<AchievementBinding>()
					.SetItem(achieve, achieve.id);
			}
			
			_loadingMarker.SetActive(false);
		}
	}
}
