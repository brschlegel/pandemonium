// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Hub"",
            ""id"": ""d6094b6b-c4f4-44a4-87ee-4dd6c4b7edfa"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""1026937e-fccb-4e53-9165-a0f38a4ed92a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9d50dc84-8dea-47f5-b21c-5c870bae6354"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""de977fc1-1022-4049-ac98-f527659d67b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""2294a089-73de-45ed-94d7-574272514b6b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6196020c-ea9c-4cc1-867f-0ea91a8cd50d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WASD"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e5ed468e-01a2-47be-a88f-8e910a90f81c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WASD"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""38ddefca-da22-4828-9492-763d2e14d215"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WASD"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9df26a3e-8d2a-4053-9868-0a7ac13e8ccd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WASD"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0ac32d2a-932a-4179-b6eb-97f724f409db"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcafd9e2-bbfd-4521-adee-c9b6a42b63f6"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea97c976-dc50-4dd7-984a-ffd2fd01ac37"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WASD"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3868c10f-649b-4d06-a11f-f3900c9e3688"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bec984b-cc02-4c69-80ab-317c2537f987"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4b27f8a-3e49-4e9e-81e6-69edb6e972b6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""WASD"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95f11dfd-2063-4146-b640-59a65d9b9aea"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f74045a-7482-44f1-a9de-1ecae4b2505d"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SceneChange"",
            ""id"": ""07777c77-6fee-43cb-9afa-95e38db59acd"",
            ""actions"": [
                {
                    ""name"": ""Scene1"",
                    ""type"": ""Button"",
                    ""id"": ""f21e579e-73a1-455b-bb6f-451953ca1497"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scene2"",
                    ""type"": ""Button"",
                    ""id"": ""f3af779f-2579-4fdc-9349-74842cc5e8ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scene3"",
                    ""type"": ""Button"",
                    ""id"": ""8cbe7c65-e4a2-4071-8e72-118f6c27d746"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7741aeec-9581-463d-96a0-9fbc74e710ea"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scene1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82c7accd-e509-4737-a8f6-f337a0c1bec7"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scene2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7f4f7ba-6381-4472-a368-671af650646f"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scene3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PS4"",
            ""bindingGroup"": ""PS4"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""WASD"",
            ""bindingGroup"": ""WASD"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Hub
        m_Hub = asset.FindActionMap("Hub", throwIfNotFound: true);
        m_Hub_Movement = m_Hub.FindAction("Movement", throwIfNotFound: true);
        m_Hub_Jump = m_Hub.FindAction("Jump", throwIfNotFound: true);
        m_Hub_Dash = m_Hub.FindAction("Dash", throwIfNotFound: true);
        // SceneChange
        m_SceneChange = asset.FindActionMap("SceneChange", throwIfNotFound: true);
        m_SceneChange_Scene1 = m_SceneChange.FindAction("Scene1", throwIfNotFound: true);
        m_SceneChange_Scene2 = m_SceneChange.FindAction("Scene2", throwIfNotFound: true);
        m_SceneChange_Scene3 = m_SceneChange.FindAction("Scene3", throwIfNotFound: true);
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

    // Hub
    private readonly InputActionMap m_Hub;
    private IHubActions m_HubActionsCallbackInterface;
    private readonly InputAction m_Hub_Movement;
    private readonly InputAction m_Hub_Jump;
    private readonly InputAction m_Hub_Dash;
    public struct HubActions
    {
        private @InputMaster m_Wrapper;
        public HubActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Hub_Movement;
        public InputAction @Jump => m_Wrapper.m_Hub_Jump;
        public InputAction @Dash => m_Wrapper.m_Hub_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Hub; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HubActions set) { return set.Get(); }
        public void SetCallbacks(IHubActions instance)
        {
            if (m_Wrapper.m_HubActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_HubActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_HubActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_HubActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_HubActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_HubActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_HubActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_HubActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_HubActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_HubActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_HubActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public HubActions @Hub => new HubActions(this);

    // SceneChange
    private readonly InputActionMap m_SceneChange;
    private ISceneChangeActions m_SceneChangeActionsCallbackInterface;
    private readonly InputAction m_SceneChange_Scene1;
    private readonly InputAction m_SceneChange_Scene2;
    private readonly InputAction m_SceneChange_Scene3;
    public struct SceneChangeActions
    {
        private @InputMaster m_Wrapper;
        public SceneChangeActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Scene1 => m_Wrapper.m_SceneChange_Scene1;
        public InputAction @Scene2 => m_Wrapper.m_SceneChange_Scene2;
        public InputAction @Scene3 => m_Wrapper.m_SceneChange_Scene3;
        public InputActionMap Get() { return m_Wrapper.m_SceneChange; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SceneChangeActions set) { return set.Get(); }
        public void SetCallbacks(ISceneChangeActions instance)
        {
            if (m_Wrapper.m_SceneChangeActionsCallbackInterface != null)
            {
                @Scene1.started -= m_Wrapper.m_SceneChangeActionsCallbackInterface.OnScene1;
                @Scene1.performed -= m_Wrapper.m_SceneChangeActionsCallbackInterface.OnScene1;
                @Scene1.canceled -= m_Wrapper.m_SceneChangeActionsCallbackInterface.OnScene1;
                @Scene2.started -= m_Wrapper.m_SceneChangeActionsCallbackInterface.OnScene2;
                @Scene2.performed -= m_Wrapper.m_SceneChangeActionsCallbackInterface.OnScene2;
                @Scene2.canceled -= m_Wrapper.m_SceneChangeActionsCallbackInterface.OnScene2;
                @Scene3.started -= m_Wrapper.m_SceneChangeActionsCallbackInterface.OnScene3;
                @Scene3.performed -= m_Wrapper.m_SceneChangeActionsCallbackInterface.OnScene3;
                @Scene3.canceled -= m_Wrapper.m_SceneChangeActionsCallbackInterface.OnScene3;
            }
            m_Wrapper.m_SceneChangeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Scene1.started += instance.OnScene1;
                @Scene1.performed += instance.OnScene1;
                @Scene1.canceled += instance.OnScene1;
                @Scene2.started += instance.OnScene2;
                @Scene2.performed += instance.OnScene2;
                @Scene2.canceled += instance.OnScene2;
                @Scene3.started += instance.OnScene3;
                @Scene3.performed += instance.OnScene3;
                @Scene3.canceled += instance.OnScene3;
            }
        }
    }
    public SceneChangeActions @SceneChange => new SceneChangeActions(this);
    private int m_PS4SchemeIndex = -1;
    public InputControlScheme PS4Scheme
    {
        get
        {
            if (m_PS4SchemeIndex == -1) m_PS4SchemeIndex = asset.FindControlSchemeIndex("PS4");
            return asset.controlSchemes[m_PS4SchemeIndex];
        }
    }
    private int m_WASDSchemeIndex = -1;
    public InputControlScheme WASDScheme
    {
        get
        {
            if (m_WASDSchemeIndex == -1) m_WASDSchemeIndex = asset.FindControlSchemeIndex("WASD");
            return asset.controlSchemes[m_WASDSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IHubActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface ISceneChangeActions
    {
        void OnScene1(InputAction.CallbackContext context);
        void OnScene2(InputAction.CallbackContext context);
        void OnScene3(InputAction.CallbackContext context);
    }
}
