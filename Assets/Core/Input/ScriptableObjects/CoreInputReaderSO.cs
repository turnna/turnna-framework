using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// This class is responsible for reading input actions and raising corresponding events.
/// It implements the CoreControl.IUIActions interface to handle UI input actions.
/// The input actions include Click, Navigate, and Escape, which are mapped to event channels.
/// </summary>
[CreateAssetMenu(fileName = "CoreInputReaderSO", menuName = "Input/CoreInputReaderSO")]
public class CoreInputReaderSO : DescriptionSO, CoreControl.IGameActions
{
    private CoreControl m_CoreControl;

    [Header("Listen to event channels")]
    public VoidEventChannelSO m_DisableGameInputChannel;
    public VoidEventChannelSO m_EnableGameInputChannel;

    [Header("Game Input Events")]
    public VoidEventChannelSO m_GameEscapeEventChannel;
    public VoidEventChannelSO m_GameClickEventChannel;

    public void OnEnable()
    {
        if (m_CoreControl == null)
        {
            m_CoreControl = new CoreControl();
            m_CoreControl.Game.SetCallbacks(this);
        }

        // Event Channels
        m_DisableGameInputChannel.OnEventRaised += DisableGameInput;
        m_EnableGameInputChannel.OnEventRaised += EnableGameInput;
    }

    public void OnDisable()
    {
        m_CoreControl.Disable();

        // Event Channels
        m_DisableGameInputChannel.OnEventRaised -= DisableGameInput;
        m_EnableGameInputChannel.OnEventRaised -= EnableGameInput;
    }

    public void EnableGameInput()
    {
        m_CoreControl.Game.Enable();
    }
    public void DisableGameInput()
    {
        m_CoreControl.Game.Disable();
    }


    public void OnEscape(InputAction.CallbackContext context)
    {
        if (m_CoreControl.Game.Escape.WasPerformedThisFrame())
        {
            m_GameEscapeEventChannel.RaiseEvent();
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (m_CoreControl.Game.Click.WasPerformedThisFrame())
        {
            m_GameClickEventChannel.RaiseEvent();
        }
    }
}
