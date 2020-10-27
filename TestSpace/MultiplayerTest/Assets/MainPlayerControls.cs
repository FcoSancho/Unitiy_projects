// GENERATED AUTOMATICALLY FROM 'Assets/MainPlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainPlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainPlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainPlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""6502f40e-edaa-41f3-9261-0b0e9e7d3267"",
            ""actions"": [
                {
                    ""name"": ""MovementJoysticks"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3e71def6-85da-4c99-bcb4-178b5bd76024"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MovementButtonsX"",
                    ""type"": ""Button"",
                    ""id"": ""0600252b-b193-4ffa-8a53-966e78524a57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MovementButtonsY"",
                    ""type"": ""Button"",
                    ""id"": ""319b1da8-ab0e-46c0-b9cd-d820a7575ebd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""67fd2ec9-46a0-4825-865b-51ef93069aef"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 controller"",
                    ""action"": ""MovementJoysticks"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows_X"",
                    ""id"": ""4d0b4289-9492-408d-aaf1-cb078f13ab8e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementButtonsX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""93c37b86-4a9d-40d3-adae-031554154dd7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MovementButtonsX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ad6f1780-8a59-40a8-8deb-27b809e359cb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MovementButtonsX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD_X"",
                    ""id"": ""7d7dce61-c63c-4d64-afe3-e217d29fe7fa"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementButtonsX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""72ec31fe-eb91-4753-ae0e-67c1e7b73060"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MovementButtonsX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""99bdba05-f276-4c5b-a9a6-79abe4cd810d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MovementButtonsX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows_Y"",
                    ""id"": ""e3a33113-8c4e-442e-9fbb-d5a15d7deddf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementButtonsY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""400c2343-cfd0-4f7a-bc44-a57eb55ea4c1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MovementButtonsY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5cee6f08-5cab-4042-83a2-dae4adaf80c7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MovementButtonsY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD_Y"",
                    ""id"": ""e830fd0e-09cb-4c74-a9fd-0ebc5af06222"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementButtonsY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5e0fe71b-c7eb-4c8b-82e5-0a3de134eb75"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MovementButtonsY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b189fe86-56b9-4e5d-b841-759cee19e76f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MovementButtonsY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and mouse"",
            ""bindingGroup"": ""Keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PS4 controller"",
            ""bindingGroup"": ""PS4 controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MovementJoysticks = m_Player.FindAction("MovementJoysticks", throwIfNotFound: true);
        m_Player_MovementButtonsX = m_Player.FindAction("MovementButtonsX", throwIfNotFound: true);
        m_Player_MovementButtonsY = m_Player.FindAction("MovementButtonsY", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MovementJoysticks;
    private readonly InputAction m_Player_MovementButtonsX;
    private readonly InputAction m_Player_MovementButtonsY;
    public struct PlayerActions
    {
        private @MainPlayerControls m_Wrapper;
        public PlayerActions(@MainPlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementJoysticks => m_Wrapper.m_Player_MovementJoysticks;
        public InputAction @MovementButtonsX => m_Wrapper.m_Player_MovementButtonsX;
        public InputAction @MovementButtonsY => m_Wrapper.m_Player_MovementButtonsY;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MovementJoysticks.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementJoysticks;
                @MovementJoysticks.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementJoysticks;
                @MovementJoysticks.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementJoysticks;
                @MovementButtonsX.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementButtonsX;
                @MovementButtonsX.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementButtonsX;
                @MovementButtonsX.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementButtonsX;
                @MovementButtonsY.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementButtonsY;
                @MovementButtonsY.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementButtonsY;
                @MovementButtonsY.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementButtonsY;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementJoysticks.started += instance.OnMovementJoysticks;
                @MovementJoysticks.performed += instance.OnMovementJoysticks;
                @MovementJoysticks.canceled += instance.OnMovementJoysticks;
                @MovementButtonsX.started += instance.OnMovementButtonsX;
                @MovementButtonsX.performed += instance.OnMovementButtonsX;
                @MovementButtonsX.canceled += instance.OnMovementButtonsX;
                @MovementButtonsY.started += instance.OnMovementButtonsY;
                @MovementButtonsY.performed += instance.OnMovementButtonsY;
                @MovementButtonsY.canceled += instance.OnMovementButtonsY;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardandmouseSchemeIndex = -1;
    public InputControlScheme KeyboardandmouseScheme
    {
        get
        {
            if (m_KeyboardandmouseSchemeIndex == -1) m_KeyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and mouse");
            return asset.controlSchemes[m_KeyboardandmouseSchemeIndex];
        }
    }
    private int m_PS4controllerSchemeIndex = -1;
    public InputControlScheme PS4controllerScheme
    {
        get
        {
            if (m_PS4controllerSchemeIndex == -1) m_PS4controllerSchemeIndex = asset.FindControlSchemeIndex("PS4 controller");
            return asset.controlSchemes[m_PS4controllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovementJoysticks(InputAction.CallbackContext context);
        void OnMovementButtonsX(InputAction.CallbackContext context);
        void OnMovementButtonsY(InputAction.CallbackContext context);
    }
}
