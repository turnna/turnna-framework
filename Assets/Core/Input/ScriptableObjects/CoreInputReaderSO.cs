using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Assets.Core.Utilities.ScriptableObjects;
using Assets.Core.Input;


namespace Assets.Core.Input.ScriptableObjects
{

    /// <summary>
    /// This serves as an intermediary object between the InputActions and the GameObjects receiving input.
    /// GameObjects listen for UnityActions instead of subscribing to InputSystem events directly.
    /// </summary>
    [CreateAssetMenu(fileName = "CoreInputReaderSO", menuName = "Input/CoreInputReaderSO")]
    public class CoreInputReaderSO : DescriptionSO, CoreControl.IUIActions
    {
        private CoreControl m_CoreControl;

        public event UnityAction<Vector2> Navigate = delegate { };
        public event UnityAction Click = delegate { };
        public event UnityAction Escape = delegate { };


        public void OnEnable()
        {
            if (m_CoreControl == null)
            {
                m_CoreControl = new CoreControl();
                m_CoreControl.UI.SetCallbacks(this);
                m_CoreControl.Enable();
            }
        }

        public void OnDisable()
        {
            m_CoreControl.Disable();
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            Click?.Invoke();
        }

        public void OnNavigate(InputAction.CallbackContext context)
        {
            Navigate?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnEscape(InputAction.CallbackContext context)
        {
            Escape?.Invoke();
        }


    }
}
