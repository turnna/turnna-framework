using UnityEditor;
/// <summary>
/// Editor script to add a custom Inspector to the BoolEventChannelSO. This uses a custom
/// ListView to show all subscribed listeners.
/// </summary>
[CustomEditor(typeof(BoolEventChannelSO))]
public class BoolEventChannelSOEditor : GenericEventChannelSOEditor<bool>
{

}
