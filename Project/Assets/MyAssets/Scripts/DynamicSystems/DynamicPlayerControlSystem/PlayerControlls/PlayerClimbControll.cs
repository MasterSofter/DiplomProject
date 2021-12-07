using System;
using UnityEngine;
using DynamicSystems.Interfaces;
using System.Collections.Generic;
namespace DynamicSystems.PlayerControlls
{
    public class PlayerClimbControll : IPlayerControll
    {
        protected float _turnSmoothVelocity;
        protected float _turnSmoothTime = 0.1f;
        protected float _targetAngle, _angle;

        private EventsSystem _eventsSystem;

        GameObject _climbWallObject;
        private bool _climbing = false;
        private bool _jumpPressed = false;

        public PlayerClimbControll(EventsSystem eventsSystem) {
            _eventsSystem = eventsSystem;
            SubscribeEvents();
        }

        public Quaternion Evaluate(Vector2 directionMoveInputXY, Transform playerTransform, GameObject climbWallObject)
        {
            Quaternion viewRotation = new Quaternion();
            Vector3 moveDirection = new Vector3();

            GameObject climbPoint = _climbWallObject.GetComponent<ClimbWall>().ClimbPoint;
            playerTransform.parent = _climbWallObject.transform.parent;
            playerTransform.position = new Vector3(climbPoint.transform.position.x, playerTransform.position.y, climbPoint.transform.position.z);


            return climbWallObject.transform.rotation;

        }

        public void OnJumpButtonPressedEventHandler(GameObject playerRoot)
        {
            _jumpPressed = true;

            if (_climbWallObject != null)
            {
                if (_jumpPressed && _climbWallObject != null)
                {
                    if (!_climbing)
                    {
                        ClimbWall climbWall = _climbWallObject.GetComponent<ClimbWall>();
                        if ((climbWall.TopWall.position - playerRoot.transform.position).y > 0)
                        {
                            _eventsSystem.Animation_StartClimbingUpWallEvent?.Invoke();
                            _climbing = true;
                        }
                    }
                }
            }
        }

        public void OnTopClimbWallDetectedEventHadler()
        {
            if (_climbing)
            {
                _eventsSystem.Animation_FinishClimbimgUpWallEvent?.Invoke();
                _climbing = false;
            }
        }

        public void OnJumpButtonReleaseEventHandler() => _jumpPressed = false;
        public void OnClimbAreaDetectedEventHandler(GameObject climbWallObject, GameObject playerRoot) => _climbWallObject = climbWallObject;

        private void SubscribeEvents() {
            _eventsSystem.ClimbAreaDetectedEvent += OnClimbAreaDetectedEventHandler;
            _eventsSystem.ButtonJumpPressedEvent += OnJumpButtonPressedEventHandler;
            _eventsSystem.ButtonJumpReleaseEvent += OnJumpButtonReleaseEventHandler;
            _eventsSystem.TopClimbWallDetectedEvent += OnTopClimbWallDetectedEventHadler;
        }
    }
}