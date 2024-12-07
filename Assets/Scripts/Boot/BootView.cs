using Boot.Systems;
using Core.Enums;
using GameLogic;
using Presentation;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Boot
{
    public class BootView : MonoBehaviour
    {
        [SerializeField]
        EventSystem _eventSystem;
        static bool _isCoreSceneLoaded = false;

        void Awake()
        {
            Application.backgroundLoadingPriority = ThreadPriority.High;
            DependencyInjectorSystem.BindConfigs();
            SignalSystem.BindSignals();

            DontDestroyOnLoad(this);
            DontDestroyOnLoad(_eventSystem);
        }

        void Start()
        {
            SceneManager.sceneLoaded += (scene, _) =>
            {
                if (scene.buildIndex == Constants.CoreSceneIndex)
                {
                    SceneManager.UnloadSceneAsync(Constants.BootSceneIndex);
                    _isCoreSceneLoaded = true;
                    OnCoreSceneLoaded();
                }
                else if (scene.buildIndex == Constants.UISceneIndex)
                {
                    UIViewModel.OnUISceneLoaded();
                }
                else if (scene.buildIndex == Constants.MainMenuSceneIndex)
                {
                    MainMenuOnEntry();
                }
                else
                    OnLevelLoaded(scene.buildIndex);
            };


            SceneManager.sceneUnloaded += (scene) =>
            {
                if(scene.buildIndex == Constants.BootSceneIndex)
                {

                }
                else if (scene.buildIndex == Constants.MainMenuSceneIndex)
                {
                    MainMenuOnExit();
                }
            };

            SceneManager.LoadSceneAsync(Constants.CoreSceneIndex, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(Constants.UISceneIndex, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(Constants.MainMenuSceneIndex, LoadSceneMode.Additive);
        }

        void Update()
        {
            if (!_isCoreSceneLoaded)
                return;

            PresentationViewModel.CustomUpdate();
            UIViewModel.CustomUpdate();
            GameLogicViewModel.CustomUpdate();
        }

        void LateUpdate()
        {
            if (!_isCoreSceneLoaded)
                return;

            PresentationViewModel.CustomLateUpdate();
            UIViewModel.CustomLateUpdate();
            GameLogicViewModel.CustomLateUpdate();
        }

        void FixedUpdate()
        {
            if (!_isCoreSceneLoaded)
                return;

            PresentationViewModel.CustomFixedUpdate();
            UIViewModel.CustomFixedUpdate();
            GameLogicViewModel.CustomFixedUpdate();
        }

        public static void OnCoreSceneLoaded()
        {
            PresentationViewModel.OnCoreSceneLoaded();
            UIViewModel.OnCoreSceneLoaded();
            GameLogicViewModel.OnCoreSceneLoaded();
        }

        public static void MainMenuOnEntry()
        {
            PresentationViewModel.MainMenuOnEntry();
            UIViewModel.MainMenuOnEntry();
            GameLogicViewModel.MainMenuOnEntry();
        }

        public static void MainMenuOnExit()
        {
            PresentationViewModel.MainMenuOnExit();
            UIViewModel.MainMenuOnExit();
            GameLogicViewModel.MainMenuOnExit();
        }

        public static void GameplayOnEntry()
        {
            PresentationViewModel.GameplayOnEntry();
            UIViewModel.GameplayOnEntry();
            GameLogicViewModel.GameplayOnEntry();
        }

        public static void GameplayOnExit()
        {
            PresentationViewModel.GameplayOnExit();
            UIViewModel.GameplayOnExit();
            GameLogicViewModel.GameplayOnExit();
        }

        public static void OnLevelLoaded(int levelIndex)
        {
            PresentationViewModel.OnLevelLoaded(levelIndex);
            UIViewModel.OnLevelLoaded(levelIndex);
            GameLogicViewModel.OnLevelLoaded(levelIndex);
        }
    }
}
