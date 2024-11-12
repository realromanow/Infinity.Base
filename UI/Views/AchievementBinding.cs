using Plugins.Infinity.DI.Binding;
using Plugins.Infinity.Player.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Infinity.Base.UI.Views {
	public class AchievementBinding : ItemBinding<AchievementModel> {
		[SerializeField]
		private TextMeshProUGUI _achievementName;

		[SerializeField]
		private Image _progressBar;

		protected override void RegisterInitialize () {
			base.RegisterInitialize();
			
			var localization = item.id;
			_achievementName.text = localization;
			_progressBar.fillAmount = item.progress;
		}
	}
}
