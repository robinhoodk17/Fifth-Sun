//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Controls/PilotingBindings.inputactions
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

public partial class @PilotingBindings : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PilotingBindings()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PilotingBindings"",
    ""maps"": [
        {
            ""name"": ""PilotingLeft"",
            ""id"": ""58b8552c-f0f5-4fd7-8cd1-35713ab71fcb"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""5bf59292-3c02-4206-9287-a5e00996f2de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""ae0b939a-0349-4d95-a0e1-924d5384f5ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""645ac6f3-5d0c-42f6-8e83-b48a6d357c67"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8db12763-9ec1-4be0-8d7b-807cfe158189"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6a657a1-8d20-465b-b75c-2ee11cc7365b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfec2fae-45f9-4095-a218-5ee8eb1dc5b5"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21c3ff02-05f9-40b9-a352-ba71c8bd3643"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7b20181-70fc-4364-a89a-06c305bfae80"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04b79aa7-dd1d-4f96-9ed7-294864dcb31a"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9edbd906-49c9-40fe-a918-0c12f3d2dc45"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32c06f05-26fd-4043-9fb1-8fc29ee4aa9c"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c98e8f99-6aa3-4c4a-afac-4a8d9a1bac79"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a251ab33-b193-4ecb-aaf7-e962e378c40f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone(min=0.1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4ddf05be-6b0b-4720-9b9e-0c3f5fbd6d7f"",
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
                    ""id"": ""972ad2fb-ce02-417d-86e3-2b8a8cee11ac"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""840e4b68-46ae-42b0-8b40-8d58c938fdd2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""98614dcf-2f29-40a0-a540-7d34db8419ac"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ff746e93-08d8-40d1-aa7f-13f118c11eb0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""TurretRight"",
            ""id"": ""847758c6-bf0b-4fae-8ba1-9a81bbe6a339"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""f8857a6b-5338-4345-bbff-37563d352bea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""16193d01-86d4-44fd-92d5-aabea20fd021"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9697783-9f02-4170-a49a-dac6ea1962dd"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerSelect"",
            ""id"": ""f441510c-7cf8-461e-88ae-f9af05b19465"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""1f9a3c06-84b4-4e6e-a84d-14b770abe0bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b09c7822-030b-47b8-a854-467510c8b9c1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""58a2e98f-94a2-45b8-bc94-9c0cbca9397b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1112b8df-4a89-48ea-ad1f-c9c5d9eac440"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a9ac95f-dfe7-4be6-bbd2-5a03bf37c78a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4c30011-a3ab-49e9-bdcf-123c5e3bb38b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b86dd143-27f7-43dc-81b4-029fb1347feb"",
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
                    ""id"": ""0565d41f-b10a-4347-83b7-db0f67042906"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""59354fcf-0640-403e-a541-0eddc4d9ea0e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0b99764b-0030-4765-b19b-4842f3d055a3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6409da39-4bd5-4496-abff-88b82ef5dd9f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
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
        }
    ]
}");
        // PilotingLeft
        m_PilotingLeft = asset.FindActionMap("PilotingLeft", throwIfNotFound: true);
        m_PilotingLeft_Accelerate = m_PilotingLeft.FindAction("Accelerate", throwIfNotFound: true);
        m_PilotingLeft_Brake = m_PilotingLeft.FindAction("Brake", throwIfNotFound: true);
        m_PilotingLeft_Move = m_PilotingLeft.FindAction("Move", throwIfNotFound: true);
        // TurretRight
        m_TurretRight = asset.FindActionMap("TurretRight", throwIfNotFound: true);
        m_TurretRight_Shoot = m_TurretRight.FindAction("Shoot", throwIfNotFound: true);
        // PlayerSelect
        m_PlayerSelect = asset.FindActionMap("PlayerSelect", throwIfNotFound: true);
        m_PlayerSelect_Select = m_PlayerSelect.FindAction("Select", throwIfNotFound: true);
        m_PlayerSelect_Move = m_PlayerSelect.FindAction("Move", throwIfNotFound: true);
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

    // PilotingLeft
    private readonly InputActionMap m_PilotingLeft;
    private IPilotingLeftActions m_PilotingLeftActionsCallbackInterface;
    private readonly InputAction m_PilotingLeft_Accelerate;
    private readonly InputAction m_PilotingLeft_Brake;
    private readonly InputAction m_PilotingLeft_Move;
    public struct PilotingLeftActions
    {
        private @PilotingBindings m_Wrapper;
        public PilotingLeftActions(@PilotingBindings wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_PilotingLeft_Accelerate;
        public InputAction @Brake => m_Wrapper.m_PilotingLeft_Brake;
        public InputAction @Move => m_Wrapper.m_PilotingLeft_Move;
        public InputActionMap Get() { return m_Wrapper.m_PilotingLeft; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PilotingLeftActions set) { return set.Get(); }
        public void SetCallbacks(IPilotingLeftActions instance)
        {
            if (m_Wrapper.m_PilotingLeftActionsCallbackInterface != null)
            {
                @Accelerate.started -= m_Wrapper.m_PilotingLeftActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_PilotingLeftActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_PilotingLeftActionsCallbackInterface.OnAccelerate;
                @Brake.started -= m_Wrapper.m_PilotingLeftActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_PilotingLeftActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_PilotingLeftActionsCallbackInterface.OnBrake;
                @Move.started -= m_Wrapper.m_PilotingLeftActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PilotingLeftActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PilotingLeftActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PilotingLeftActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PilotingLeftActions @PilotingLeft => new PilotingLeftActions(this);

    // TurretRight
    private readonly InputActionMap m_TurretRight;
    private ITurretRightActions m_TurretRightActionsCallbackInterface;
    private readonly InputAction m_TurretRight_Shoot;
    public struct TurretRightActions
    {
        private @PilotingBindings m_Wrapper;
        public TurretRightActions(@PilotingBindings wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_TurretRight_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_TurretRight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TurretRightActions set) { return set.Get(); }
        public void SetCallbacks(ITurretRightActions instance)
        {
            if (m_Wrapper.m_TurretRightActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_TurretRightActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_TurretRightActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_TurretRightActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_TurretRightActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public TurretRightActions @TurretRight => new TurretRightActions(this);

    // PlayerSelect
    private readonly InputActionMap m_PlayerSelect;
    private IPlayerSelectActions m_PlayerSelectActionsCallbackInterface;
    private readonly InputAction m_PlayerSelect_Select;
    private readonly InputAction m_PlayerSelect_Move;
    public struct PlayerSelectActions
    {
        private @PilotingBindings m_Wrapper;
        public PlayerSelectActions(@PilotingBindings wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_PlayerSelect_Select;
        public InputAction @Move => m_Wrapper.m_PlayerSelect_Move;
        public InputActionMap Get() { return m_Wrapper.m_PlayerSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerSelectActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerSelectActions instance)
        {
            if (m_Wrapper.m_PlayerSelectActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_PlayerSelectActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerSelectActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerSelectActionsCallbackInterface.OnSelect;
                @Move.started -= m_Wrapper.m_PlayerSelectActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerSelectActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerSelectActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PlayerSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PlayerSelectActions @PlayerSelect => new PlayerSelectActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPilotingLeftActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface ITurretRightActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IPlayerSelectActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
