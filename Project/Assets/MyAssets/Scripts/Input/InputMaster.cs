// GENERATED AUTOMATICALLY FROM 'Assets/MyAssets/Scripts/Input/InputMaster.inputactions'

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
            ""name"": ""Player"",
            ""id"": ""41b16955-6f2f-4794-b03d-733ecb6ee4ac"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cb9ed45e-05a7-4b73-9a8d-35eed5007f6f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""a4b14a81-dc87-42ec-ace8-cfc818f63920"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""bd4934df-0e56-4e78-8186-12057cb64181"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartRun"",
                    ""type"": ""Button"",
                    ""id"": ""2a7ad220-48ac-4fad-95f3-723d29aeb379"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonPressedJump"",
                    ""type"": ""Button"",
                    ""id"": ""e5455e04-a886-4fc3-98b5-118fc64e89d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonReleaseJump"",
                    ""type"": ""Button"",
                    ""id"": ""1179615b-cbae-41cc-a129-b6425a49ad0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopRun"",
                    ""type"": ""Button"",
                    ""id"": ""d7cebf51-2732-479b-86f1-7f260b79bedc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LightsaberOnOff"",
                    ""type"": ""Button"",
                    ""id"": ""21bc8a1e-97e4-46e1-8e3a-de1e40f25e8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonPressedReadyBlockAttack"",
                    ""type"": ""Button"",
                    ""id"": ""3ab8e79e-8323-40fc-8508-b0a7611080b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonReleaseReadyBlockAttack"",
                    ""type"": ""Button"",
                    ""id"": ""95117d39-d4b5-4f42-adff-2ad7b212289d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aa4fab8a-9cf8-4b87-8e81-5cbb7900aed9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0f2cccc-61ba-46e3-a324-9af8eadbba25"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""4d8418fe-aa9e-45f5-a43a-a0e8e01321c7"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f4816da2-8c3f-4389-ad7a-04fe11b20f9e"",
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
                    ""id"": ""0803ea32-12dc-4eb1-89dd-99f3307c17d3"",
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
                    ""id"": ""9ff4c74c-e9c6-4cd0-9cf8-9fdd3cba1b9e"",
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
                    ""id"": ""59608840-87b7-48b3-a56f-b0e2d60cdc0b"",
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
                    ""id"": ""3443e14e-27e2-4599-8447-fba5ce3f8947"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartRun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96a4b63b-ab20-42e7-bf00-235aea7d32a0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonPressedJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96cc828b-cc0c-4735-ba9e-09b843dc10ef"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonReleaseJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7981cd82-3654-4975-91b8-7d085dde0010"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopRun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6e29ad3-3c42-457a-93f0-77aa2ecf307e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightsaberOnOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe49a07d-9df0-4750-9c21-b69d3a876e57"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonPressedReadyBlockAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""323f15c8-97ae-4525-9dbb-3ab2444385b8"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonReleaseReadyBlockAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_StartRun = m_Player.FindAction("StartRun", throwIfNotFound: true);
        m_Player_ButtonPressedJump = m_Player.FindAction("ButtonPressedJump", throwIfNotFound: true);
        m_Player_ButtonReleaseJump = m_Player.FindAction("ButtonReleaseJump", throwIfNotFound: true);
        m_Player_StopRun = m_Player.FindAction("StopRun", throwIfNotFound: true);
        m_Player_LightsaberOnOff = m_Player.FindAction("LightsaberOnOff", throwIfNotFound: true);
        m_Player_ButtonPressedReadyBlockAttack = m_Player.FindAction("ButtonPressedReadyBlockAttack", throwIfNotFound: true);
        m_Player_ButtonReleaseReadyBlockAttack = m_Player.FindAction("ButtonReleaseReadyBlockAttack", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_StartRun;
    private readonly InputAction m_Player_ButtonPressedJump;
    private readonly InputAction m_Player_ButtonReleaseJump;
    private readonly InputAction m_Player_StopRun;
    private readonly InputAction m_Player_LightsaberOnOff;
    private readonly InputAction m_Player_ButtonPressedReadyBlockAttack;
    private readonly InputAction m_Player_ButtonReleaseReadyBlockAttack;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @StartRun => m_Wrapper.m_Player_StartRun;
        public InputAction @ButtonPressedJump => m_Wrapper.m_Player_ButtonPressedJump;
        public InputAction @ButtonReleaseJump => m_Wrapper.m_Player_ButtonReleaseJump;
        public InputAction @StopRun => m_Wrapper.m_Player_StopRun;
        public InputAction @LightsaberOnOff => m_Wrapper.m_Player_LightsaberOnOff;
        public InputAction @ButtonPressedReadyBlockAttack => m_Wrapper.m_Player_ButtonPressedReadyBlockAttack;
        public InputAction @ButtonReleaseReadyBlockAttack => m_Wrapper.m_Player_ButtonReleaseReadyBlockAttack;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @StartRun.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartRun;
                @StartRun.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartRun;
                @StartRun.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartRun;
                @ButtonPressedJump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonPressedJump;
                @ButtonPressedJump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonPressedJump;
                @ButtonPressedJump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonPressedJump;
                @ButtonReleaseJump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonReleaseJump;
                @ButtonReleaseJump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonReleaseJump;
                @ButtonReleaseJump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonReleaseJump;
                @StopRun.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStopRun;
                @StopRun.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStopRun;
                @StopRun.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStopRun;
                @LightsaberOnOff.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLightsaberOnOff;
                @LightsaberOnOff.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLightsaberOnOff;
                @LightsaberOnOff.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLightsaberOnOff;
                @ButtonPressedReadyBlockAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonPressedReadyBlockAttack;
                @ButtonPressedReadyBlockAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonPressedReadyBlockAttack;
                @ButtonPressedReadyBlockAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonPressedReadyBlockAttack;
                @ButtonReleaseReadyBlockAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonReleaseReadyBlockAttack;
                @ButtonReleaseReadyBlockAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonReleaseReadyBlockAttack;
                @ButtonReleaseReadyBlockAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonReleaseReadyBlockAttack;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @StartRun.started += instance.OnStartRun;
                @StartRun.performed += instance.OnStartRun;
                @StartRun.canceled += instance.OnStartRun;
                @ButtonPressedJump.started += instance.OnButtonPressedJump;
                @ButtonPressedJump.performed += instance.OnButtonPressedJump;
                @ButtonPressedJump.canceled += instance.OnButtonPressedJump;
                @ButtonReleaseJump.started += instance.OnButtonReleaseJump;
                @ButtonReleaseJump.performed += instance.OnButtonReleaseJump;
                @ButtonReleaseJump.canceled += instance.OnButtonReleaseJump;
                @StopRun.started += instance.OnStopRun;
                @StopRun.performed += instance.OnStopRun;
                @StopRun.canceled += instance.OnStopRun;
                @LightsaberOnOff.started += instance.OnLightsaberOnOff;
                @LightsaberOnOff.performed += instance.OnLightsaberOnOff;
                @LightsaberOnOff.canceled += instance.OnLightsaberOnOff;
                @ButtonPressedReadyBlockAttack.started += instance.OnButtonPressedReadyBlockAttack;
                @ButtonPressedReadyBlockAttack.performed += instance.OnButtonPressedReadyBlockAttack;
                @ButtonPressedReadyBlockAttack.canceled += instance.OnButtonPressedReadyBlockAttack;
                @ButtonReleaseReadyBlockAttack.started += instance.OnButtonReleaseReadyBlockAttack;
                @ButtonReleaseReadyBlockAttack.performed += instance.OnButtonReleaseReadyBlockAttack;
                @ButtonReleaseReadyBlockAttack.canceled += instance.OnButtonReleaseReadyBlockAttack;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnStartRun(InputAction.CallbackContext context);
        void OnButtonPressedJump(InputAction.CallbackContext context);
        void OnButtonReleaseJump(InputAction.CallbackContext context);
        void OnStopRun(InputAction.CallbackContext context);
        void OnLightsaberOnOff(InputAction.CallbackContext context);
        void OnButtonPressedReadyBlockAttack(InputAction.CallbackContext context);
        void OnButtonReleaseReadyBlockAttack(InputAction.CallbackContext context);
    }
}
