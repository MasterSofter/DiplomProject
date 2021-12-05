using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicSystems.Interfaces;
using DynamicSystems.PlayerControlls;
namespace DynamicSystems {
    /// <summary>
    /// Система, решающая задачу преключение контроллеров, управляющих
    /// игроком, в зависимости от контекста
    /// </summary>
    public class DynamicPlayerControllSystem 
    {
        private IPlayerControll _playerMoveControll, _playerParkourControll;

        private EventsSystem _eventsSystem;
        private GameObject _obstacleObject;
        private bool _playerLookToObstacle = false;

        private bool _jumpPressed = false;


        public DynamicPlayerControllSystem(EventsSystem eventsSystem) {
            _eventsSystem = eventsSystem;
            _playerMoveControll = new PlayerMoveControll();

            SubscribeEvents();
        }


        public void OnMoveEventHandler(Vector2 direction, string[] parameterNames, GameObject playerRoot, GameObject camera)
        {
            Quaternion viewRotation;

            viewRotation = _playerMoveControll.Evaluate(direction, playerRoot.transform, camera);
            playerRoot.transform.rotation = viewRotation;
        }

        public void OnJumpButtonPressedEventHandler(GameObject playerRoot) {
            if(!_jumpPressed)
                _jumpPressed = true;
        }

        public void OnJumpButtonReleaseEventHandler() {
            _jumpPressed = false;
        }

        public void OnObstacleDetectedEventHandler(GameObject obstacleObject, GameObject playerRoot ) {
            _obstacleObject = obstacleObject;

            if (_jumpPressed && _obstacleObject != null)
            {
                if (_obstacleObject.tag == "JumpOverObstacle")
                    _eventsSystem.JumpOverObstacleEvent?.Invoke();
                if (_obstacleObject.tag == "VaultOverObstacle")
                    _eventsSystem.VaultOverObstacleEvent?.Invoke();
            }
        }

        public void OnObstacleMissedEventHandler(GameObject obstacleObject, GameObject playerRoot)
        {
            if (_obstacleObject == obstacleObject)
                _obstacleObject = null;
        }

        private void SubscribeEvents()
        {
            _eventsSystem.MoveEvent += OnMoveEventHandler;
            _eventsSystem.ButtonJumpPressedEvent += OnJumpButtonPressedEventHandler;
            _eventsSystem.ButtonJumpReleaseEvent += OnJumpButtonReleaseEventHandler;
            _eventsSystem.ObstacleDetectedEvent += OnObstacleDetectedEventHandler;
            _eventsSystem.ObstacleMissedEvent += OnObstacleMissedEventHandler;
        }
    }
}


