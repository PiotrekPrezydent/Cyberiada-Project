using UI.Enums;
using UI.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        Button _startButton;

        [SerializeField]
        Button _settingsButton;

        [SerializeField]
        Button _exitButton;

        void Start()
        {
            _startButton.onClick.AddListener(OnStart);
            _settingsButton.onClick.AddListener(OnSettings);
            _exitButton.onClick.AddListener(OnExit);
        }

        void OnStart()
        {
            //Request change game state to gameplay
        }

        void OnSettings()
        {
            PopupSystem.OpenPopup(PopupType.SettingsPopup);
        }

        void OnExit()
        {
            //exit
        }
    }
}
