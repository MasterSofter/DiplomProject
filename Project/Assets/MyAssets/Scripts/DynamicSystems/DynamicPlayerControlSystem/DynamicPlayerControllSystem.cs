using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicSystems.PlayerControlls;
using DynamicSystems.Interfaces;
namespace DynamicSystems {
    /// <summary>
    /// Система, решающая задачу преключение контроллеров, управляющих
    /// игроком, в зависимости от контекста
    /// </summary>
    public class DynamicPlayerControllSystem 
    {
        private IPlayerControll _playerMoveControll, _playerClimbControll;

        private EventsSystem _eventsSystem;

        private GameObject _climbWallObject;
        private bool _climbing = false;


        public DynamicPlayerControllSystem(EventsSystem eventsSystem) {
            _eventsSystem = eventsSystem;
            _playerMoveControll = new PlayerMoveControll(eventsSystem);
            _playerClimbControll = new PlayerClimbControll(eventsSystem);

            SubscribeEvents();
        }


        public void OnMoveEventHandler(Vector2 direction, string[] parameterNames, GameObject playerRoot, GameObject camera)
        {
            Quaternion viewRotation;
            Vector3 moveDirection;

            if (!_climbing){
                viewRotation = _playerMoveControll.Evaluate(direction, playerRoot.transform, camera);
                _eventsSystem.Animation_MoveEvent(direction, parameterNames);
            }
            else {
                if (_climbWallObject != null)
                {
                    viewRotation = _playerClimbControll.Evaluate(direction, playerRoot.transform, _climbWallObject);
                    _eventsSystem.Animation_MoveEvent(new Vector2(direction.x, direction.y), parameterNames);
                }
                else
                    viewRotation = playerRoot.transform.rotation;
               
            }
            playerRoot.transform.rotation = viewRotation;
        }

        public void OnJumpButtonPressedEventHandler(GameObject playerRoot)
        {
            if (_climbWallObject != null)
            {
                ClimbWall climbWall = _climbWallObject.GetComponent<ClimbWall>();
                if ((climbWall.TopWall.position - playerRoot.transform.position).y > 0)
                    _climbing = true;
            }    
        }

        public void OnClimbAreaMissedEventHandler(GameObject climbWallObject, GameObject playerRoot) => _climbWallObject = null;
        public void OnClimbAreaDetectedEventHandler(GameObject climbWallObject, GameObject playerRoot) => _climbWallObject = climbWallObject;

        public void OnTopClimbWallDetectedEventHadler() => _climbing = false;

        public void OnStartRunEventHandler() => _eventsSystem.Animation_StartRunEvent?.Invoke();
        public void OnFinishRunEventHadler() => _eventsSystem.Animation_FinishRunEvent?.Invoke();


        private void SubscribeEvents()
        {
            _eventsSystem.MoveEvent += OnMoveEventHandler;
            _eventsSystem.ButtonJumpPressedEvent += OnJumpButtonPressedEventHandler;
            _eventsSystem.ClimbAreaDetectedEvent += OnClimbAreaDetectedEventHandler;
            _eventsSystem.ClimbAreaMissedEvent += OnClimbAreaMissedEventHandler;
            _eventsSystem.StartRunEvent += OnStartRunEventHandler;
            _eventsSystem.FinishRunEvent += OnFinishRunEventHadler;
            _eventsSystem.TopClimbWallDetectedEvent += OnTopClimbWallDetectedEventHadler;
        }
    }
}


