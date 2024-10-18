using UnityEngine;
using UnityEngine.UI;

namespace Infinity.Base.UI.Components {
	public class ButtonThemeSwitcherComponent : MonoBehaviour {
		[SerializeField]
		private Image _button;

		[SerializeField]
		private Sprite _enabledTheme;

		[SerializeField]
		private Sprite _disabledTheme;

		[SerializeField]
		private bool _defaultState;

		public bool isActiveState { get; private set; }

		private void Start () {
			isActiveState = _defaultState;
			SetupTrueSprite();
		}

		public void SwitchTheme () {
			isActiveState = !isActiveState;
			SetupTrueSprite();
		}

		private void SetupTrueSprite () {
			_button.sprite = isActiveState ? _enabledTheme : _disabledTheme;
		}
	}
}
