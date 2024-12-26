using UnityEngine;

/// <summary>
/// A Scriptable Object-based event that passes a Vector2 as a payload.
/// </summary>
[CreateAssetMenu(fileName = "Vector2EventChannelSO", menuName = "Events/Vector2EventChannelSO ")]
public class Vector2EventChannelSO : GenericEventChannelSO<Vector2>
{
}