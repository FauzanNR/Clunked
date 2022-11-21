//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputSetting/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""MovementController"",
            ""id"": ""280a9b0c-4c6b-4a08-b334-05284f94b678"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""18038fdd-dfb6-4164-987d-edd2f5990efe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press,Hold"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""048c8416-d06a-43cd-b40f-7445a6908456"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""039377a1-08a4-40d2-922b-c7ba1dcbbc79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""78a4f81a-17de-4ae9-9fb1-9cce603cf838"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4cad898b-e1e3-43cc-8266-a4bbf29f0809"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d9954b5b-ad99-4d57-b848-058fa8b45214"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""01da5189-20d6-49ab-9dad-470bccc6467d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6fb49a31-f284-4233-9417-22736cf5c851"",
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
                    ""id"": ""4ba7767d-5d09-431c-88c2-ec7ba3beae5c"",
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
                    ""id"": ""c9f7fa11-8388-4d7b-acbd-f8b08179e05c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MovementController
        m_MovementController = asset.FindActionMap("MovementController", throwIfNotFound: true);
        m_MovementController_Move = m_MovementController.FindAction("Move", throwIfNotFound: true);
        m_MovementController_Jump = m_MovementController.FindAction("Jump", throwIfNotFound: true);
        m_MovementController_Fire = m_MovementController.FindAction("Fire", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MovementController
    private readonly InputActionMap m_MovementController;
    private IMovementControllerActions m_MovementControllerActionsCallbackInterface;
    private readonly InputAction m_MovementController_Move;
    private readonly InputAction m_MovementController_Jump;
    private readonly InputAction m_MovementController_Fire;
    public struct MovementControllerActions
    {
        private @PlayerInput m_Wrapper;
        public MovementControllerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MovementController_Move;
        public InputAction @Jump => m_Wrapper.m_MovementController_Jump;
        public InputAction @Fire => m_Wrapper.m_MovementController_Fire;
        public InputActionMap Get() { return m_Wrapper.m_MovementController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementControllerActions set) { return set.Get(); }
        public void SetCallbacks(IMovementControllerActions instance)
        {
            if (m_Wrapper.m_MovementControllerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnJump;
                @Fire.started -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_MovementControllerActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_MovementControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public MovementControllerActions @MovementController => new MovementControllerActions(this);
    public interface IMovementControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
