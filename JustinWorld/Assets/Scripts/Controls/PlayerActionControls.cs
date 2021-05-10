// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActionControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActionControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Basic"",
            ""id"": ""89a6a2b7-d60e-40b1-a843-29e9bf321b5d"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""07c4730a-5061-45cf-8fc9-8f26c49a3985"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1ba375ce-19a6-45b5-820d-eacc85e59178"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookUp"",
                    ""type"": ""Button"",
                    ""id"": ""ee99987e-a060-48d1-b9f3-47d08dcd3966"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""130721df-17b3-4a3c-83cc-5fb60aaa2e62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9fcdc5b4-d998-4af1-91de-dcfaa0240d84"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6632613-a1f7-4c26-8232-011cf63c17c3"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6dd7104-159f-4201-8636-ed2f71412fa4"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37624c41-e136-43e3-83f5-24391d30c21d"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Basic
        m_Basic = asset.FindActionMap("Basic", throwIfNotFound: true);
        m_Basic_Jump = m_Basic.FindAction("Jump", throwIfNotFound: true);
        m_Basic_Movement = m_Basic.FindAction("Movement", throwIfNotFound: true);
        m_Basic_LookUp = m_Basic.FindAction("LookUp", throwIfNotFound: true);
        m_Basic_Crouch = m_Basic.FindAction("Crouch", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Basic
    private readonly InputActionMap m_Basic;
    private IBasicActions m_BasicActionsCallbackInterface;
    private readonly InputAction m_Basic_Jump;
    private readonly InputAction m_Basic_Movement;
    private readonly InputAction m_Basic_LookUp;
    private readonly InputAction m_Basic_Crouch;
    public struct BasicActions
    {
        private @PlayerActionControls m_Wrapper;
        public BasicActions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Basic_Jump;
        public InputAction @Movement => m_Wrapper.m_Basic_Movement;
        public InputAction @LookUp => m_Wrapper.m_Basic_LookUp;
        public InputAction @Crouch => m_Wrapper.m_Basic_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_Basic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicActions set) { return set.Get(); }
        public void SetCallbacks(IBasicActions instance)
        {
            if (m_Wrapper.m_BasicActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnMovement;
                @LookUp.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnLookUp;
                @LookUp.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnLookUp;
                @LookUp.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnLookUp;
                @Crouch.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_BasicActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @LookUp.started += instance.OnLookUp;
                @LookUp.performed += instance.OnLookUp;
                @LookUp.canceled += instance.OnLookUp;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public BasicActions @Basic => new BasicActions(this);
    public interface IBasicActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnLookUp(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
}
