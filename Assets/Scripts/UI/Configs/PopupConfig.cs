using UnityEngine;

namespace UI.Configs
{
    [CreateAssetMenu(fileName ="PopupConfig", menuName = "Config/UI/PopupConfig")]
    class PopupConfig : ScriptableObject
    {
        //td: why the fuck unity dont see prefabs with this?
        //the below is temporary not efficient solution
        [SerializeField]
        internal AbstractPopup[] AbstractPopups;

        [SerializeField]
        GameObject[] _abstractPopups;

        internal AbstractPopup Get(int i) => _abstractPopups[i].GetComponent<AbstractPopup>(); 

        internal int Size => _abstractPopups.Length;
    }
}
