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


        public void OnMoveEventHandler(Vector2 direction, string[] parameterNames, GameObject rootPlayer, GameObject camera) {

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

        private void SubscribeEvents() {
            _eventsSystem.MoveEvent += OnMoveEventHandler;
            _eventsSystem.StartRunEvent += OnStartRunEventHandler;
            _eventsSystem.StopRunEvent += OnStopRunEventHandler;
            _eventsSystem.JumpOverObstacleEvent += OnJumpOverObstacle;
            _eventsSystem.VaultOverObstacleEvent += OnVaultOverObstacle;
        }
    }

}
