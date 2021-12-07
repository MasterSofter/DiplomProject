using System;
using UnityEngine;
using DynamicSystems.Interfaces;
namespace DynamicSystems.PlayerControlls {
    
    public class PlayerMoveControll : IPlayerControll
    {
        protected float _turnSmoothVelocity;
        protected float _turnSmoothTime = 0.1f;
        protected float _targetAngle, _angle;

        private EventsSystem _eventsSystem;
        private GameObject _obstacleObject;
        private bool _jumpPressed = false;

        public PlayerMoveControll(EventsSystem eventsSystem) {
            _eventsSystem = eventsSystem;

            SubscribeEvents();
        }

        public Quaternion Evaluate(Vector2 directionMoveInputXZ, Transform playerTransform, GameObject camera) {
            Quaternion viewRotation = new Quaternion();
            playerTransform.parent = null;

            if (directionMoveInputXZ.magnitude > 0)
            {
                Vector3 moveDirection
                    = (directionMoveInputXZ.x * camera.transform.right) + (directionMoveInputXZ.y * camera.transform.forward);

                _targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                _angle = Mathf.SmoothDampAngle(playerTransform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                viewRotation = Quaternion.Euler(0f, _angle, 0f);

                return viewRotation;
            }
            else return playerTransform.rotation;
            
        }

        public void OnObstacleDetectedEventHandler(GameObject obstacleObject, GameObject playerRoot){
            _obstacleObject = obstacleObject;
        }
        public void OnObstacleMissedEventHandler(GameObject obstacleObject, GameObject playerRoot){
            if (_obstacleObject == obstacleObject)
                _obstacleObject = null;
        }

        public void OnJumpButtonPressedEventHandler(GameObject playerRoot)
        {
            _jumpPressed = true;

            if (_jumpPressed && _obstacleObject != null)
            {
                if (_obstacleObject.tag == "JumpOverObstacle")
                    _eventsSystem.Animation_JumpOverObstacleEvent?.Invoke();
                if (_obstacleObject.tag == "VaultOverObstacle")
                    _eventsSystem.Animation_VaultOverObstacleEvent?.Invoke();
                _obstacleObject = null;
            }
        }
        public void OnJumpButtonReleaseEventHandler() => _jumpPressed = false;

        private void SubscribeEvents() {
            _eventsSystem.ObstacleDetectedEvent += OnObstacleDetectedEventHandler;
            _eventsSystem.ObstacleMissedEvent += OnObstacleMissedEventHandler;
            _eventsSystem.ButtonJumpPressedEvent += OnJumpButtonPressedEventHandler;
            _eventsSystem.ButtonJumpReleaseEvent += OnJumpButtonReleaseEventHandler;
        }
    }
}

