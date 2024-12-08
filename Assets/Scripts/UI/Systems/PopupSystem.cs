using System.Collections.Generic;
using UI.Configs;
using UI.Enums;
using UnityEngine;

namespace UI.Systems
{
    static class PopupSystem
    {
        static readonly PopupConfig _config;
        static Stack<AbstractPopup> _popups = new();
        internal static void OpenPopup(PopupType type)
        {
            if (!InputSystem.PopuMap.enabled)
                InputSystem.PopuMap.Enable();
            

            for (int i = 0; i < _config.Size; i++)
            {
                if (_config.Get(i).Type != type)
                    continue;
                _popups.Push(GameObject.Instantiate(_config.Get(i), UIViewModel.UIReferences.PopupContainer.transform));
                _popups.Peek().Initialize();
                break;
            }
        }

        internal static void ClosePopup()
        {
            var popup = _popups.Pop();;
            GameObject.Destroy(popup.gameObject);
            if (_popups.Count == 0)
                InputSystem.PopuMap.Disable();

        }

        internal static AbstractPopup CurrentPopup => _popups.Peek();
    }
}
