using UnityEditor;
using Assets.Core.EventChannels.ScriptableObjects;

namespace Assets.Core.EventChannels.Editors
{
    /// <summary>
    /// Editor script to add a custom Inspector to the FloatEventChannelSO. This uses a custom
    /// ListView to show all subscribed listeners.
    /// </summary>
    [CustomEditor(typeof(SceneFieldChannelSO))]
    public class SceneFieldChannelSOEditor : GenericEventChannelSOEditor<SceneField>
    {

    }
}
