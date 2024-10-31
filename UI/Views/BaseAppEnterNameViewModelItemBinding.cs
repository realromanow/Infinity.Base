using Infinity.Base.UI.ViewModels;
using Infinity.Extensions;
using Plugins.Infinity.DI.Binding;
using TMPro;
using UniRx;
using UnityEngine;

namespace Infinity.Base.UI.Views {
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
	}
}
