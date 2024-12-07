using UI.Enums;
using UI.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.Popups
{
    [DisallowMultipleComponent]
    class SettingsPopup : AbstractPopup
    {
        [SerializeField]
        Button _exitButton;

        internal override PopupType Type => PopupType.SettingsPopup;

        internal override void Initialize()
        {
            _exitButton.onClick.AddListener(OnExitClick);
        }

        internal override void Close()
        {
            //save settings on close
        }

        void OnExitClick()
        {
            PopupSystem.ClosePopup();
        }


    }
}
