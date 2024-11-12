using Plugins.Infinity.DI.Binding;
using Plugins.Infinity.Player.Models;
using TMPro;
using UnityEngine;

namespace Plugins.Infinity.Base.UI.Views {
	public class LeaderboardPlayerModelBinding : ItemBinding<LeaderboardPlayerModel> {
		[SerializeField]
		private TextMeshProUGUI _rankLabel;
		
		[SerializeField]
		private TextMeshProUGUI _scoreLabel;
		
		[SerializeField]
		private TextMeshProUGUI _nameLabel;

		protected override void RegisterInitialize () {
			base.RegisterInitialize();
			
			_rankLabel.text = $"{item.position}";
			_scoreLabel.text = $"{item.score}";
			_nameLabel.text = $"{item.displayName}";
		}
	}
}
