using UI.Configs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI.Systems
{
    static class InputSystem
    {
        static readonly UIConfig _config;
        internal static InputActionMap MainMenuMap;
        internal static InputActionMap PopuMap;
        internal static void Initialize()
        {
            MainMenuMap = _config.InputActions.FindActionMap("MainMenuActionMap");
            PopuMap = _config.InputActions.FindActionMap("PopupMap");

            MainMenuMap.FindAction("Console").performed += _ =>
            {
                Debug.Log("Console");
            };

            PopuMap.FindAction("Close").performed += _ =>
            {
                PopupSystem.ClosePopup();
            };

            PopuMap.Disable();
        }
    }
}
