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
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f347eb34-7a16-4edd-a90c-abe25c141073"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""ba844c82-fea1-4ed1-8dfc-9dfcadf86195"",
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
                    ""id"": ""ac5720e4-aa34-405a-a303-a49bd71b987f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
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
                    ""id"": ""5a661ef1-c36a-4ccf-83eb-cf3b6376438a"",
                    ""path"": ""<Keyboard>/w"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""f2df773d-413f-4396-88e8-3d3155d7ab6c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""GamepadAxis"",
                    ""id"": ""980cb11b-8553-4cee-82d3-6e5100c2cd50"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""45a52646-e467-4860-9e23-e77a986b282a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2b1d396f-6087-4a7a-9284-401fd75821b5"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyboardAxis"",
                    ""id"": ""ce02a2c8-504d-464e-9570-d208d46ec9a9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""10de52c7-de41-4f5e-b502-527276e3497b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2892b6e8-9b4b-491c-af0e-f49c05eb110f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""083a900f-dde3-4dcc-be54-39d4816df7f1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43a14f0e-0843-4713-961a-2f8956910473"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
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
        m_Basic_LookUp = m_Basic.FindAction("LookUp", throwIfNotFound: true);
        m_Basic_Crouch = m_Basic.FindAction("Crouch", throwIfNotFound: true);
        m_Basic_Move = m_Basic.FindAction("Move", throwIfNotFound: true);
        m_Basic_Interact = m_Basic.FindAction("Interact", throwIfNotFound: true);
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
    private readonly InputAction m_Basic_LookUp;
    private readonly InputAction m_Basic_Crouch;
    private readonly InputAction m_Basic_Move;
    private readonly InputAction m_Basic_Interact;
    public struct BasicActions
    {
        private @PlayerActionControls m_Wrapper;
        public BasicActions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Basic_Jump;
        public InputAction @LookUp => m_Wrapper.m_Basic_LookUp;
        public InputAction @Crouch => m_Wrapper.m_Basic_Crouch;
        public InputAction @Move => m_Wrapper.m_Basic_Move;
        public InputAction @Interact => m_Wrapper.m_Basic_Interact;
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
                @LookUp.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnLookUp;
                @LookUp.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnLookUp;
                @LookUp.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnLookUp;
                @Crouch.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnCrouch;
                @Move.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_BasicActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LookUp.started += instance.OnLookUp;
                @LookUp.performed += instance.OnLookUp;
                @LookUp.canceled += instance.OnLookUp;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public BasicActions @Basic => new BasicActions(this);
    public interface IBasicActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnLookUp(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
