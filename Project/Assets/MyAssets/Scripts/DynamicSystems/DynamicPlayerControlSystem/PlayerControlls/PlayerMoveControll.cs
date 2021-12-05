using System;
using UnityEngine;
using DynamicSystems.Interfaces;
namespace DynamicSystems.PlayerControlls {
    
    public class PlayerMoveControll : IPlayerControll
    {
        protected float _turnSmoothVelocity;
        protected float _turnSmoothTime = 0.1f;
        protected float _targetAngle, _angle;

        public Quaternion Evaluate(Vector2 directionMoveInputXZ, Transform playerTransform, GameObject camera) {
            Quaternion viewRotation = new Quaternion();

            if (directionMoveInputXZ.magnitude > 0)
            {
                Vector3 moveDirection
                    = (directionMoveInputXZ.x * camera.transform.right) + (directionMoveInputXZ.y * camera.transform.forward);


                Vector3 vecViewDirection = Vector3.ProjectOnPlane(
                (camera.transform.forward).normalized, Vector3.up);

                _targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                _angle = Mathf.SmoothDampAngle(playerTransform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                viewRotation = Quaternion.Euler(0f, _angle, 0f);

                return viewRotation;
            }
            else return playerTransform.rotation;
            
        }
    }
}

