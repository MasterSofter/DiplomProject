using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using DynamicSystems;

public class PlayerController : MonoBehaviour
{
    private DynamicAnimationsSystem _animationSystem;           //система динамеческого управления анимациями
    private DynamicPlayerControllSystem _playerControllSystem;  //система динамического управления игроком
    private EventsSystem _eventsSystem;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _playerMeshRoot;

    private Vector2 _direction = new Vector2();



    [SerializeField]  private Animator _animator;
    private InputMaster _inputMasterControls;

    private void Awake()
    {
        _eventsSystem = new EventsSystem();
        _animationSystem = new DynamicAnimationsSystem(_eventsSystem, _animator);

        _playerControllSystem = new DynamicPlayerControllSystem(_eventsSystem);

        _inputMasterControls = new InputMaster();
        _inputMasterControls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        _inputMasterControls.Player.StartRun.performed += ctx => StartRun();
        _inputMasterControls.Player.StopRun.performed += ctx => StopRun();
        _inputMasterControls.Player.ButtonPressedJump.performed += ctx => PressedButtonJump();
         _inputMasterControls.Player.ButtonReleaseJump.performed += ctx => ReleaseButtonJump();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            _eventsSystem.ObstacleDetectedEvent?.Invoke(other.gameObject, gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            _eventsSystem.ObstacleMissedEvent?.Invoke(other.gameObject, gameObject);
    }

    private void Update() =>
        _eventsSystem.MoveEvent.Invoke(_direction, new string[] { "DirectionRight", "DirectionForward" }, _playerMeshRoot, _camera);




    private void Move(Vector2 direction) => _direction = direction;
    private void StartRun() => _eventsSystem.StartRunEvent?.Invoke();
    private void StopRun() => _eventsSystem.StopRunEvent?.Invoke();
    private void PressedButtonJump() => _eventsSystem.ButtonJumpPressedEvent?.Invoke(gameObject);
    private void ReleaseButtonJump() => _eventsSystem.ButtonJumpReleaseEvent?.Invoke();


    public void EnableInputMaster() => _inputMasterControls.Enable();
    public void DisableInputMaster()
    {

        _inputMasterControls.Disable();
        _direction = new Vector2(0, 0);
    }

    private void OnEnable() => _inputMasterControls.Enable();
    private void OnDisable() => ReleaseButtonJump();
}
