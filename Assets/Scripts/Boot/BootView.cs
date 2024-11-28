using Boot.Systems;
using GameLogic;
using Presentation;
using UI;
using UnityEngine;

namespace Boot
{
    public class BootView : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this);
            DependencyInjectorSystem.BindConfigs();
            SignalSystem.BindSignals();

        }

        void Update()
        {
            PresentationViewModel.CustomUpdate();
            UIViewModel.CustomUpdate();
            GameLogicViewModel.CustomUpdate();
        }

        void LateUpdate()
        {
            PresentationViewModel.CustomLateUpdate();
            UIViewModel.CustomLateUpdate();
            GameLogicViewModel.CustomLateUpdate();
        }

        void FixedUpdate()
        {
            PresentationViewModel.CustomFixedUpdate();
            UIViewModel.CustomFixedUpdate();
            GameLogicViewModel.CustomFixedUpdate();
        }

        public static void OnBootingStared()
        {
            PresentationViewModel.OnBootingStared();
            UIViewModel.OnBootingStared();
            GameLogicViewModel.OnBootingStared();
        }

        public static void OnBootingEnded()
        {
            PresentationViewModel.OnBootingEnded();
            UIViewModel.OnBootingEnded();
            GameLogicViewModel.OnBootingEnded();
        }

        public static void OnMainMenuEnter()
        {
            PresentationViewModel.OnMainMenuEnter();
            UIViewModel.OnMainMenuEnter();
            GameLogicViewModel.OnMainMenuEnter();
        }

        public static void OnMainMenuExit()
        {
            PresentationViewModel.OnMainMenuExit();
            UIViewModel.OnMainMenuExit();
            GameLogicViewModel.OnMainMenuExit();
        }

        public static void OnGameplayEnter()
        {
            PresentationViewModel.OnGameplayEnter();
            UIViewModel.OnGameplayEnter();
            GameLogicViewModel.OnGameplayEnter();
        }

        public static void OnGameplayExit()
        {
            PresentationViewModel.OnGameplayExit();
            UIViewModel.OnGameplayExit();
            GameLogicViewModel.OnGameplayExit();
        }

        public static void OnSavingStarted()
        {
            PresentationViewModel.OnSavingStarted();
            UIViewModel.OnSavingStarted();
            GameLogicViewModel.OnSavingStarted();
        }

        public static void OnSavingEnded()
        {
            PresentationViewModel.OnSavingEnded();
            UIViewModel.OnSavingEnded();
            GameLogicViewModel.OnSavingEnded();
        }

        public static void OnLoadingStarted()
        {
            PresentationViewModel.OnLoadingStarted();
            UIViewModel.OnLoadingStarted();
            GameLogicViewModel.OnLoadingStarted();
        }

        public static void OnLoadingEnded()
        {
            PresentationViewModel.OnLoadingEnded();
            UIViewModel.OnLoadingEnded();
            GameLogicViewModel.OnLoadingEnded();
        }
    }
}
