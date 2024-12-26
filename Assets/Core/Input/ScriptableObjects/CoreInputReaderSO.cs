using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// This class is responsible for reading input actions and raising corresponding events.
/// It implements the CoreControl.IUIActions interface to handle UI input actions.
/// The input actions include Click, Navigate, and Escape, which are mapped to event channels.
/// </summary>
[CreateAssetMenu(fileName = "CoreInputReaderSO", menuName = "Input/CoreInputReaderSO")]
public class CoreInputReaderSO : DescriptionSO, CoreControl.IGameplayActions
{
    private CoreControl m_CoreControl;

    public VoidEventChannelSO m_InputEscapeEventChannel;

    public void OnEnable()
    {
        if (m_CoreControl == null)
        {
            m_CoreControl = new CoreControl();
            m_CoreControl.Gameplay.SetCallbacks(this);
        }
    }

    public void OnDisable()
    {
        m_CoreControl.Disable();
    }

    public void EnableGameplayInput()
    {
        m_CoreControl.Gameplay.Enable();
    }
    public void DisableGameplayInput()
    {
        m_CoreControl.Gameplay.Disable();
    }


    public void OnEscape(InputAction.CallbackContext context)
    {
        if (m_CoreControl.Gameplay.Escape.WasPerformedThisFrame())
        {
            m_InputEscapeEventChannel.RaiseEvent();
        }
    }
}
