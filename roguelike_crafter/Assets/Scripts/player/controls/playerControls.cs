//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Scripts/player/controls/playerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""playerControls"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""056b2231-0dea-43e2-89fc-c9afc0490e12"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""55e55c34-e955-4e37-a9b5-3e57582f8c61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""77d84d8e-8a58-4bda-9c88-387afe1d65ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""4e346543-718a-4a21-882f-025c7c75a592"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""3b1a005c-b83a-429a-920e-f80d919f9744"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""48a66091-350a-4f9d-85e6-97d3d8eb88e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""a3e46c90-926a-4859-9745-8e7e93e7c36c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5a1c2a41-3d9d-435e-be71-0b71a98f2116"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability_1"",
                    ""type"": ""Button"",
                    ""id"": ""56204bcf-54af-48d2-96a9-b0911128ec2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability_2"",
                    ""type"": ""Button"",
                    ""id"": ""2970534c-910b-455a-8c8d-af7a0cd6b66b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability_3"",
                    ""type"": ""Button"",
                    ""id"": ""bb9394da-efbe-484b-a3e2-ece33908734b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability_4"",
                    ""type"": ""Button"",
                    ""id"": ""14169715-6a5d-4030-a913-d14050a88d99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability_5"",
                    ""type"": ""Button"",
                    ""id"": ""5044c61d-fe15-4394-b316-4f1aa3babe81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""use_item"",
                    ""type"": ""Button"",
                    ""id"": ""8f9c257e-bc0b-4e7f-a148-0687f82d3d07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GetMouseDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""60f69b48-0044-4fe5-a0f0-5f85733535c2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7b64e5b3-4b80-4af4-83df-6e46e2691b1f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df738aa3-21c9-40cf-82f8-03af7cac4b08"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dd39349-eb8b-441f-a553-c3953949c6d4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4f13760-ae15-4807-b5c0-8cacb3ec5f33"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""938ee444-713c-49f7-9f3a-56ccb2a504dd"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8bf6b48-f03b-4748-b1e3-b45198eb8c59"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39ba872e-7edb-4438-91ff-17222c89bdec"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df6afcba-bbd5-4ddf-9dc7-07a31a52138d"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability_4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d34e207-38da-4b27-9abd-42423e571f24"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability_5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""916e9f14-1264-4861-9c05-be9f11fba753"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04141a05-7f03-4612-9690-0a6956dcd6f9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""use_item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4d3fd7d-fd35-41ba-9620-1de06220a723"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""809a317d-3302-43e8-9695-857ec43fbe1a"",
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
                    ""id"": ""b31a34e2-9954-40fa-82c9-6ff00159456b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetMouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // player
        m_player = asset.FindActionMap("player", throwIfNotFound: true);
        m_player_Forward = m_player.FindAction("Forward", throwIfNotFound: true);
        m_player_Backward = m_player.FindAction("Backward", throwIfNotFound: true);
        m_player_Left = m_player.FindAction("Left", throwIfNotFound: true);
        m_player_Right = m_player.FindAction("Right", throwIfNotFound: true);
        m_player_Slide = m_player.FindAction("Slide", throwIfNotFound: true);
        m_player_Sprint = m_player.FindAction("Sprint", throwIfNotFound: true);
        m_player_Jump = m_player.FindAction("Jump", throwIfNotFound: true);
        m_player_Ability_1 = m_player.FindAction("Ability_1", throwIfNotFound: true);
        m_player_Ability_2 = m_player.FindAction("Ability_2", throwIfNotFound: true);
        m_player_Ability_3 = m_player.FindAction("Ability_3", throwIfNotFound: true);
        m_player_Ability_4 = m_player.FindAction("Ability_4", throwIfNotFound: true);
        m_player_Ability_5 = m_player.FindAction("Ability_5", throwIfNotFound: true);
        m_player_use_item = m_player.FindAction("use_item", throwIfNotFound: true);
        m_player_GetMouseDelta = m_player.FindAction("GetMouseDelta", throwIfNotFound: true);
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

    // player
    private readonly InputActionMap m_player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_player_Forward;
    private readonly InputAction m_player_Backward;
    private readonly InputAction m_player_Left;
    private readonly InputAction m_player_Right;
    private readonly InputAction m_player_Slide;
    private readonly InputAction m_player_Sprint;
    private readonly InputAction m_player_Jump;
    private readonly InputAction m_player_Ability_1;
    private readonly InputAction m_player_Ability_2;
    private readonly InputAction m_player_Ability_3;
    private readonly InputAction m_player_Ability_4;
    private readonly InputAction m_player_Ability_5;
    private readonly InputAction m_player_use_item;
    private readonly InputAction m_player_GetMouseDelta;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_player_Forward;
        public InputAction @Backward => m_Wrapper.m_player_Backward;
        public InputAction @Left => m_Wrapper.m_player_Left;
        public InputAction @Right => m_Wrapper.m_player_Right;
        public InputAction @Slide => m_Wrapper.m_player_Slide;
        public InputAction @Sprint => m_Wrapper.m_player_Sprint;
        public InputAction @Jump => m_Wrapper.m_player_Jump;
        public InputAction @Ability_1 => m_Wrapper.m_player_Ability_1;
        public InputAction @Ability_2 => m_Wrapper.m_player_Ability_2;
        public InputAction @Ability_3 => m_Wrapper.m_player_Ability_3;
        public InputAction @Ability_4 => m_Wrapper.m_player_Ability_4;
        public InputAction @Ability_5 => m_Wrapper.m_player_Ability_5;
        public InputAction @use_item => m_Wrapper.m_player_use_item;
        public InputAction @GetMouseDelta => m_Wrapper.m_player_GetMouseDelta;
        public InputActionMap Get() { return m_Wrapper.m_player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @Left.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Slide.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlide;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Ability_1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_1;
                @Ability_1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_1;
                @Ability_1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_1;
                @Ability_2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_2;
                @Ability_2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_2;
                @Ability_2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_2;
                @Ability_3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_3;
                @Ability_3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_3;
                @Ability_3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_3;
                @Ability_4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_4;
                @Ability_4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_4;
                @Ability_4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_4;
                @Ability_5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_5;
                @Ability_5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_5;
                @Ability_5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility_5;
                @use_item.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse_item;
                @use_item.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse_item;
                @use_item.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse_item;
                @GetMouseDelta.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGetMouseDelta;
                @GetMouseDelta.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGetMouseDelta;
                @GetMouseDelta.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGetMouseDelta;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Ability_1.started += instance.OnAbility_1;
                @Ability_1.performed += instance.OnAbility_1;
                @Ability_1.canceled += instance.OnAbility_1;
                @Ability_2.started += instance.OnAbility_2;
                @Ability_2.performed += instance.OnAbility_2;
                @Ability_2.canceled += instance.OnAbility_2;
                @Ability_3.started += instance.OnAbility_3;
                @Ability_3.performed += instance.OnAbility_3;
                @Ability_3.canceled += instance.OnAbility_3;
                @Ability_4.started += instance.OnAbility_4;
                @Ability_4.performed += instance.OnAbility_4;
                @Ability_4.canceled += instance.OnAbility_4;
                @Ability_5.started += instance.OnAbility_5;
                @Ability_5.performed += instance.OnAbility_5;
                @Ability_5.canceled += instance.OnAbility_5;
                @use_item.started += instance.OnUse_item;
                @use_item.performed += instance.OnUse_item;
                @use_item.canceled += instance.OnUse_item;
                @GetMouseDelta.started += instance.OnGetMouseDelta;
                @GetMouseDelta.performed += instance.OnGetMouseDelta;
                @GetMouseDelta.canceled += instance.OnGetMouseDelta;
            }
        }
    }
    public PlayerActions @player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAbility_1(InputAction.CallbackContext context);
        void OnAbility_2(InputAction.CallbackContext context);
        void OnAbility_3(InputAction.CallbackContext context);
        void OnAbility_4(InputAction.CallbackContext context);
        void OnAbility_5(InputAction.CallbackContext context);
        void OnUse_item(InputAction.CallbackContext context);
        void OnGetMouseDelta(InputAction.CallbackContext context);
    }
}
