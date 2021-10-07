// GENERATED AUTOMATICALLY FROM 'Assets/InputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""PlayerInput"",
            ""id"": ""2d5c49ac-77bc-4ee6-b1e1-714bc5a71ce2"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""f9920a25-795f-46dc-9d5b-a45163d089c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Value"",
                    ""id"": ""8f1f894a-85c5-4c42-81f6-b3553c59f5e9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Value"",
                    ""id"": ""ff7346b1-6552-4fb6-b071-68b0aff70c88"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Value"",
                    ""id"": ""2d8f2e29-bb13-4c5a-b8b8-b9ef7956ffcc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""RotationKeys"",
                    ""id"": ""a6be1e43-05e9-4a53-b00d-ccfef7a177bf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c671d237-0805-401e-bbaa-3d8f3afb8635"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f756459a-4523-472e-a1b4-a5e793bf3a7c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9df58f17-37c1-4b43-98b1-61d739422221"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea22f402-8737-45cf-ae62-78097a5dc8ca"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a0da71f-0af3-4dfc-b330-4d3797002e3c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInput
        m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
        m_PlayerInput_Rotate = m_PlayerInput.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerInput_MoveForward = m_PlayerInput.FindAction("MoveForward", throwIfNotFound: true);
        m_PlayerInput_SwitchWeapon = m_PlayerInput.FindAction("SwitchWeapon", throwIfNotFound: true);
        m_PlayerInput_Fire = m_PlayerInput.FindAction("Fire", throwIfNotFound: true);
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

    // PlayerInput
    private readonly InputActionMap m_PlayerInput;
    private IPlayerInputActions m_PlayerInputActionsCallbackInterface;
    private readonly InputAction m_PlayerInput_Rotate;
    private readonly InputAction m_PlayerInput_MoveForward;
    private readonly InputAction m_PlayerInput_SwitchWeapon;
    private readonly InputAction m_PlayerInput_Fire;
    public struct PlayerInputActions
    {
        private @InputController m_Wrapper;
        public PlayerInputActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_PlayerInput_Rotate;
        public InputAction @MoveForward => m_Wrapper.m_PlayerInput_MoveForward;
        public InputAction @SwitchWeapon => m_Wrapper.m_PlayerInput_SwitchWeapon;
        public InputAction @Fire => m_Wrapper.m_PlayerInput_Fire;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotate;
                @MoveForward.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMoveForward;
                @MoveForward.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMoveForward;
                @MoveForward.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMoveForward;
                @SwitchWeapon.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnSwitchWeapon;
                @Fire.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_PlayerInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @MoveForward.started += instance.OnMoveForward;
                @MoveForward.performed += instance.OnMoveForward;
                @MoveForward.canceled += instance.OnMoveForward;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);
    public interface IPlayerInputActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnMoveForward(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
