using UnityEngine;

/// <summary>
/// A Scriptable Object-based event that passes a int as a payload.
/// </summary>
[CreateAssetMenu(fileName = "IntEventChannelSO", menuName = "Events/IntEventChannelSO ")]
public class IntEventChannelSO : GenericEventChannelSO<int>
{

}