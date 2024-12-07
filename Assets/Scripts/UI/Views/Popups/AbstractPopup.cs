using UI.Enums;
using UnityEngine;

namespace UI
{
    [DisallowMultipleComponent]
    abstract class AbstractPopup : MonoBehaviour
    {
        internal abstract PopupType Type { get; }

        internal abstract void Initialize();

        internal abstract void Close();
    }
}
