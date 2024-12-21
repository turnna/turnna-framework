using Assets.Core.SceneManagement.Scripts;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Core.EventChannels.ScriptableObjects
{
    /// <summary>
    /// A Scriptable Object-based event that passes a float as a payload.
    /// </summary>
    [CreateAssetMenu(fileName = "SceneFieldChannelSO", menuName = "Events/SceneFieldChannelSO")]
    public class SceneFieldChannelSO : GenericEventChannelSO<SceneField>
    {

    }
}