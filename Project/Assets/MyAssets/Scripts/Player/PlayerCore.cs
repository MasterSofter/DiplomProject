using UnityEngine;

using Player.Controller.CollisionsManagers;
using Player.Controller;
using Player.EventsSystem;
using Player.Viewer;
namespace Player.Core {
    [RequireComponent(typeof(Animator))]
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] private Lightsaber.Controller.LightsaberController _lightsaberController;
        [SerializeField] private ObstaclesCollisionsManager _obstaclesCollisionsManager;
        [SerializeField] private GameObject _cameraGameObject;
        [SerializeField] private Animator _animator;

        private InputMaster _inputMaster;
        private PlayerController _playerController;
        private PlayerViewer _playerViewer;
        private PlayerEventsSystem _eventsSystem;

        private void Awake()
        {
            _inputMaster = new InputMaster();
            _eventsSystem = new PlayerEventsSystem();
            _playerController = new PlayerController(_inputMaster, _eventsSystem, _lightsaberController);
            _playerViewer = new PlayerViewer(_eventsSystem, _animator, gameObject ,_cameraGameObject);

            _obstaclesCollisionsManager.Init(_eventsSystem);
        }


        private void Update()
        {
            _playerController.Update();
        }

  






        /*

         private void InitializeInputMasterControlls()
        {
            _inputMasterControls = new InputMaster();
            _inputMasterControls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
            _inputMasterControls.Player.StartRun.performed += ctx => StartRun();
            _inputMasterControls.Player.StopRun.performed += ctx => StopRun();
            _inputMasterControls.Player.ButtonPressedJump.performed += ctx => PressedButtonJump();
            _inputMasterControls.Player.ButtonReleaseJump.performed += ctx => ReleaseButtonJump();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "TopClimbWall")
                _eventsSystem.TopClimbWallDetectedEvent?.Invoke();
            if (other.gameObject.layer == LayerMask.NameToLayer("ClimbWall"))
                _eventsSystem.ClimbAreaDetectedEvent?.Invoke(other.gameObject, gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
                _eventsSystem.ObstacleDetectedEvent?.Invoke(other.gameObject, gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
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

        */
    }

}

