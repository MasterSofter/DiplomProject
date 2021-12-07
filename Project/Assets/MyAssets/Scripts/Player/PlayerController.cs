using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using DynamicSystems;

public class PlayerController : MonoBehaviour
{
    private Vector2 _direction;
    private DynamicAnimationsSystem _animationSystem;           //система динамеческого управления анимациями
    private DynamicPlayerControllSystem _playerControllSystem;  //система динамического управления игроком
    private EventsSystem _eventsSystem;

    private InputMaster _inputMasterControls;

    [SerializeField] private GameObject _camera;
    [SerializeField] private Animator _animator;

    private void Awake(){
        _eventsSystem = new EventsSystem();
        _animationSystem = new DynamicAnimationsSystem(_eventsSystem, _animator);
        _playerControllSystem = new DynamicPlayerControllSystem(_eventsSystem);
        InitializeInputMasterControlls();
    }

    private void InitializeInputMasterControlls() {
        _inputMasterControls = new InputMaster();
        _inputMasterControls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        _inputMasterControls.Player.StartRun.performed += ctx => StartRun();
        _inputMasterControls.Player.StopRun.performed += ctx => StopRun();
        _inputMasterControls.Player.ButtonPressedJump.performed += ctx => PressedButtonJump();
        _inputMasterControls.Player.ButtonReleaseJump.performed += ctx => ReleaseButtonJump();
    }


    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "TopClimbWall") 
            _eventsSystem.TopClimbWallDetectedEvent?.Invoke();
        if (other.gameObject.layer == LayerMask.NameToLayer("ClimbWall"))
            _eventsSystem.ClimbAreaDetectedEvent?.Invoke(other.gameObject, gameObject);
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            _eventsSystem.ObstacleDetectedEvent?.Invoke(other.gameObject, gameObject);
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            _eventsSystem.ObstacleMissedEvent?.Invoke(other.gameObject, gameObject);
        if (other.gameObject.layer == LayerMask.NameToLayer("ClimbWall"))
            _eventsSystem.ClimbAreaMissedEvent?.Invoke(other.gameObject, gameObject);
    }

    private void Update() =>
        _eventsSystem.MoveEvent.Invoke(_direction, new string[] { "DirectionRight", "DirectionForward" }, gameObject, _camera);


    private void Move(Vector2 direction) => _direction = direction;
    private void StartRun() => _eventsSystem.StartRunEvent?.Invoke();
    private void StopRun() => _eventsSystem.FinishRunEvent?.Invoke();
    private void PressedButtonJump() => _eventsSystem.ButtonJumpPressedEvent?.Invoke(gameObject);
    private void ReleaseButtonJump() => _eventsSystem.ButtonJumpReleaseEvent?.Invoke();

    private void OnEnable() => _inputMasterControls.Enable();
    private void OnDisable() => ReleaseButtonJump();
}
