using Infinity.Base.UI.ViewModels;
using Infinity.Extensions;
using Plugins.Infinity.DI.Binding;
using TMPro;
using UnityEngine;

namespace Infinity.Base.UI.Views {
	public class BaseAppEnterNameViewModelItemBinding : ItemBinding<BaseAppEnterNameViewModel> {
		[SerializeField]
		private TextMeshProUGUI _nameLabel;

		protected override void RegisterInitialize () {
			base.RegisterInitialize();

			_nameLabel.text = item.defaultName.Truncate(9, "...");
		}

		public void SubmitName () {
			item.SubmitName();
		}
	}
}
