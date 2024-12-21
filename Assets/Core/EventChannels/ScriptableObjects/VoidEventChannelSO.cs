
using Assets.Core.Utilities.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Core.EventChannels.ScriptableObjects
{

    [CreateAssetMenu(menuName = "Events/Void Event Channel", fileName = "VoidEventChannel")]
    public class VoidEventChannelSO : DescriptionSO
    {
        [Tooltip("The action to perform")]
        public UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke();
        }


    }

}
