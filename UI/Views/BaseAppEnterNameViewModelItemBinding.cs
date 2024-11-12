using Plugins.Infinity.Base.UI.ViewModels;
using Plugins.Infinity.DI.Binding;
using Plugins.Infinity.Extensions;
using TMPro;
using UniRx;
using UnityEngine;

namespace Plugins.Infinity.Base.UI.Views {
	public class BaseAppEnterNameViewModelItemBinding : ItemBinding<BaseAppEnterNameViewModel> {
		[SerializeField]
		private TextMeshProUGUI _nameLabel;

		protected override void RegisterInitialize () {
			base.RegisterInitialize();

			item.playerName
				.Subscribe(value => _nameLabel.text = value.Truncate(6))
				.AddTo(bindingDisposable);
		}

		public void SubmitName () {
			item.SubmitName();
		}

		public void PressSupport () {
			Application.OpenURL("https://chubbychampionsfluffparty.com/support.html");
		}
	}
}
