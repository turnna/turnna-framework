using UnityEngine;
using UnityEditor;
using Assets.Core.EventChannels.ScriptableObjects;

namespace Assets.Core.EventChannels.Editors
{
    [CustomEditor(typeof(StringEventChannelSO))]
    public class StringEventChannelSOEditor : GenericEventChannelSOEditor<string>
    {


    }
}
