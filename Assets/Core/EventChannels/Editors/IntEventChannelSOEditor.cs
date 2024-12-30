using UnityEditor;

/// <summary>
/// Editor script to add a custom Inspector to the intEventChannelSO. This uses a custom
/// ListView to show all subscribed listeners.
/// </summary>
[CustomEditor(typeof(IntEventChannelSO))]
public class IntEventChannelSOEditor : GenericEventChannelSOEditor<int>
{

}