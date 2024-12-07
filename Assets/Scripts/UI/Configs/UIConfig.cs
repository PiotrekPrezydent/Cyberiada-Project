using UnityEngine;
using UnityEngine.InputSystem;

namespace UI.Configs
{
    [CreateAssetMenu(fileName ="UIConfig", menuName = "Config/UI/UIConfig")]
    class UIConfig : ScriptableObject
    {
        [SerializeField]
        internal InputActionAsset InputActions;
    }
}
