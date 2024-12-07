using UI.Systems;
using UnityEngine;

namespace UI
{
    public static class UIViewModel
    {
        internal static UISceneReferencesHolder UIReferences;
        public static void CustomUpdate()
        {

        }

        public static void CustomLateUpdate()
        {

        }

        public static void CustomFixedUpdate()
        {

        }
        public static void OnUISceneLoaded()
        {
            UIReferences = GameObject.FindFirstObjectByType<UISceneReferencesHolder>();
        }

        public static void OnCoreSceneLoaded()
        {
            InputSystem.Initialize();
        }

        public static void MainMenuOnEntry()
        {
            //Set camera position for main menu scene
            UIReferences.Camera.transform.position = new Vector3(0, 0, 0);
        }

        public static void MainMenuOnExit()
        {

        }

        public static void GameplayOnEntry()
        {

        }

        public static void GameplayOnExit()
        {

        }

        public static void OnLevelLoaded(int levelIndex)
        {

        }
    }
}
