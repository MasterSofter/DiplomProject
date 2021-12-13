using System;
using UnityEngine;

using Player.EventsSystem;
using Lightsaber.Controller;
using Player.Model;
namespace Player.Controller {
    public class PlayerController
    {
        private Vector2 _inputDirection;
        private GameObject _obstacleObject = null;
        private LightsaberController _lightsaberController;

        private PlayerModel _playerModel;
        private PlayerEventsSystem _eventsSystem;
        private InputMaster _inputMaster;

        public PlayerController(InputMaster inputMaster, PlayerEventsSystem eventsSystem, PlayerModel playerModel ,LightsaberController lightsaberController){
            _lightsaberController = lightsaberController;
            _playerModel = playerModel;
            _eventsSystem = eventsSystem;
            _inputMaster = inputMaster;
            _inputMaster.Enable();
            InitializeInputMasterControlls();
            SubscribeEvents();
        }

        private void SubscribeEvents() {
            _eventsSystem.ObstacleDetectedEvent += OnObstacleDetectedEventHandler;
            _eventsSystem.ObstacleMissedEvent += OnObstacleMissedEventHandler;

        }

        private void InitializeInputMasterControlls()
        {
            _inputMaster.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
            _inputMaster.Player.StartRun.performed += ctx => StartRun();
            _inputMaster.Player.StopRun.performed += ctx => StopRun();
            _inputMaster.Player.ButtonPressedJump.performed += ctx => PressedButtonJump();
            _inputMaster.Player.ButtonReleaseJump.performed += ctx => ReleaseButtonJump();
            _inputMaster.Player.LightsaberOnOff.performed += ctx => LightsaberOnOff();

            _inputMaster.Player.ButtonPressedReadyBlockAttack.performed += ctx => PressedButtonReadyBlockAttack();
            _inputMaster.Player.ButtonReleaseReadyBlockAttack.performed += ctx => ReleaseButtonReadyBlockAttack();
        }


        private void PressedButtonReadyBlockAttack() {
            _eventsSystem.ViewStartReadyBlockAttackEvent?.Invoke();
        }

        private void ReleaseButtonReadyBlockAttack() {
            _eventsSystem.ViewStopReadyBlockAttackEvent?.Invoke();
        }

        private void LightsaberOnOff() =>
           _lightsaberController.LightsaberTurnOnOff();


        private void OnObstacleDetectedEventHandler(GameObject obstacleObject) => _obstacleObject = obstacleObject;
        private void OnObstacleMissedEventHandler(GameObject obstacleObject) {
            if (_obstacleObject == obstacleObject)
                _obstacleObject = null;
        }

        public void Update() {
            _eventsSystem.ViewMoveEvent?.Invoke(_inputDirection);
        }

        private void Move(Vector2 inputDirection) => _inputDirection = inputDirection;
   
        private void StartRun() => _eventsSystem.ViewStartRunEvent?.Invoke();
        private void StopRun() => _eventsSystem.ViewStopRunEvent?.Invoke();

        private void PressedButtonJump()
        {
            if (_obstacleObject != null)
            {
                if (_obstacleObject.tag == "JumpOverObstacle")
                {
                    _lightsaberController.LightsaberTurnOff();
                    _eventsSystem.ViewJumpOverObstacleEvent?.Invoke();
                    _obstacleObject = null;
                }
                else if (_obstacleObject.tag == "VaultOverObstacle")
                {
                    _eventsSystem.ViewVaultOverObstacleEvent?.Invoke();
                    _obstacleObject = null;
                }

            }
        }
        private void ReleaseButtonJump() { }

       // private void OnEnable() => _inputMasterControls.Enable();
       //  private void OnDisable() => ReleaseButtonJump();
        
    }

}

