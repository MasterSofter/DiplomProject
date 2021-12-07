using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicSystems
{
    /// <summary>
    /// Система, решающая задачу выбора и переключения нужной анимации
    /// </summary>
    public class DynamicAnimationsSystem
    {
        private EventsSystem _eventsSystem;
        private Animator _animator;

        private float _smoothAnimationTime = 0.1f;
        private Vector2 _currentAnimationBlendVector;
        private Vector2 _animationVelocity;

        public DynamicAnimationsSystem(EventsSystem eventsSystem, Animator animator) {
            _eventsSystem = eventsSystem;
            _animator = animator;

            SubscribeEvents();
        }


        public void OnMoveEventHandler(Vector2 direction, string[] parameterNames) {

            _currentAnimationBlendVector = Vector2.SmoothDamp(_currentAnimationBlendVector, direction, ref _animationVelocity, _smoothAnimationTime);

            _animator.SetFloat(parameterNames[0], _currentAnimationBlendVector.x); //движение вправо-влево
            _animator.SetFloat(parameterNames[1], _currentAnimationBlendVector.y); //движение вперед-назад
        }

        public void OnJumpOverObstacle() =>
            _animator.SetTrigger("JumpOverObstacle");

        public void OnVaultOverObstacle() =>
            _animator.SetTrigger("VaultOverObstacle");

        public void OnStartRunEventHandler() {
            _animator.SetBool("Run", true);
        }

        public void OnStopRunEventHandler() {
            _animator.SetBool("Run", false);
        }

        public void OnStartClimbingUpWall() {
            _animator.SetTrigger("ClimbingUpWall");
        }

        public void OnFinishClimbingUpWall()
        {
            _animator.SetTrigger("FinishClimbingUpWall");
        }

        

        private void SubscribeEvents() {            
            _eventsSystem.Animation_JumpOverObstacleEvent += OnJumpOverObstacle;
            _eventsSystem.Animation_VaultOverObstacleEvent += OnVaultOverObstacle;
            _eventsSystem.Animation_StartRunEvent += OnStartRunEventHandler;
            _eventsSystem.Animation_FinishRunEvent += OnStopRunEventHandler;
            _eventsSystem.Animation_MoveEvent += OnMoveEventHandler;
            _eventsSystem.Animation_StartClimbingUpWallEvent += OnStartClimbingUpWall;
            _eventsSystem.Animation_FinishClimbimgUpWallEvent += OnFinishClimbingUpWall;
        }
    }

}
