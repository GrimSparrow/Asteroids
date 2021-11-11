// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Ship"",
            ""id"": ""2f1c112b-d828-4ee3-9f68-72db5af33cda"",
            ""actions"": [
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""1841725c-6def-4119-aca0-a05adebecb94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.001,pressPoint=0.001)""
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""38aff5fa-7ed6-4a04-9a7a-a0a21f32fb5c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StandartAttack"",
                    ""type"": ""Button"",
                    ""id"": ""fdbc991b-b074-45f9-90ec-7915b6eaf162"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryAttack"",
                    ""type"": ""Button"",
                    ""id"": ""1ca411de-c2e2-4cdd-9b0a-456e2d89bf06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1c28f7a9-6283-4fc2-bbca-36f8c79d2113"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ffef0580-7af5-4210-9bc9-8e6529c67ae3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1b95fb0b-d63d-4a40-8118-99c846eeb56e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d54d5758-3151-4a28-8250-07fda114ba4f"",
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
                    ""id"": ""e39c90a2-8c69-431c-b611-d1614c016439"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StandartAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce0a83d5-4bee-43a2-9513-5f2a0d4962cd"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ship
        m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
        m_Ship_MoveForward = m_Ship.FindAction("MoveForward", throwIfNotFound: true);
        m_Ship_Rotate = m_Ship.FindAction("Rotate", throwIfNotFound: true);
        m_Ship_StandartAttack = m_Ship.FindAction("StandartAttack", throwIfNotFound: true);
        m_Ship_SecondaryAttack = m_Ship.FindAction("SecondaryAttack", throwIfNotFound: true);
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

    // Ship
    private readonly InputActionMap m_Ship;
    private IShipActions m_ShipActionsCallbackInterface;
    private readonly InputAction m_Ship_MoveForward;
    private readonly InputAction m_Ship_Rotate;
    private readonly InputAction m_Ship_StandartAttack;
    private readonly InputAction m_Ship_SecondaryAttack;
    public struct ShipActions
    {
        private @PlayerInput m_Wrapper;
        public ShipActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveForward => m_Wrapper.m_Ship_MoveForward;
        public InputAction @Rotate => m_Wrapper.m_Ship_Rotate;
        public InputAction @StandartAttack => m_Wrapper.m_Ship_StandartAttack;
        public InputAction @SecondaryAttack => m_Wrapper.m_Ship_SecondaryAttack;
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
        public void SetCallbacks(IShipActions instance)
        {
            if (m_Wrapper.m_ShipActionsCallbackInterface != null)
            {
                @MoveForward.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnMoveForward;
                @MoveForward.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnMoveForward;
                @MoveForward.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnMoveForward;
                @Rotate.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                @StandartAttack.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnStandartAttack;
                @StandartAttack.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnStandartAttack;
                @StandartAttack.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnStandartAttack;
                @SecondaryAttack.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnSecondaryAttack;
                @SecondaryAttack.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnSecondaryAttack;
                @SecondaryAttack.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnSecondaryAttack;
            }
            m_Wrapper.m_ShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveForward.started += instance.OnMoveForward;
                @MoveForward.performed += instance.OnMoveForward;
                @MoveForward.canceled += instance.OnMoveForward;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @StandartAttack.started += instance.OnStandartAttack;
                @StandartAttack.performed += instance.OnStandartAttack;
                @StandartAttack.canceled += instance.OnStandartAttack;
                @SecondaryAttack.started += instance.OnSecondaryAttack;
                @SecondaryAttack.performed += instance.OnSecondaryAttack;
                @SecondaryAttack.canceled += instance.OnSecondaryAttack;
            }
        }
    }
    public ShipActions @Ship => new ShipActions(this);
    public interface IShipActions
    {
        void OnMoveForward(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnStandartAttack(InputAction.CallbackContext context);
        void OnSecondaryAttack(InputAction.CallbackContext context);
    }
}
