using System;
using UnityEngine;

using Player.EventsSystem;
namespace Player.Viewer {
    public class PlayerViewer
    {
        private float _targetAngle, _angle, _turnSmoothVelocity;
        private float _turnSmoothTime = 0.1f;

        private float _smoothAnimationTime = 0.5f;
        Vector2 _currentAnimationBlendVector, _animationVelocity;

        private GameObject _cameraGameObject;
        private GameObject _gameObjectRoot;
        private PlayerEventsSystem _eventsSystem;
        private Animator _animator;

        public PlayerViewer(PlayerEventsSystem eventsSystem, Animator animator, GameObject gameObjectRoot, GameObject cameraGameObject)
        {
            _cameraGameObject = cameraGameObject;
            _gameObjectRoot = gameObjectRoot;
            _eventsSystem = eventsSystem;
            _animator = animator;

            SubscribeEvents();
        }


        private void SubscribeEvents()
        {
            _eventsSystem.ViewMoveEvent += OnMoveEventHandler;
            _eventsSystem.ViewStartRunEvent += OnStartRunEventHandler;
            _eventsSystem.ViewStopRunEvent += OnStopRunEventHandler;
            _eventsSystem.ViewJumpOverObstacleEvent += OnJumpOverObstacleEventHandler;
            _eventsSystem.ViewVaultOverObstacleEvent += OnVaultOverObstacleEventHandler;

            _eventsSystem.ViewStartReadyBlockAttackEvent += OnStartReadyBlockAttackEventHandler;
            _eventsSystem.ViewStopReadyBlockAttackEvent += OnStopReadyBlockAttackEventHandler;

            _eventsSystem.ViewAttackEvent += OnAttackEventHandler;
            _eventsSystem.ViewBlockAttackEvent += OnViewBlockAttackHandler;
        }

        private void OnViewBlockAttackHandler() {
            _animator.SetTrigger("BlockAttack");
        }

        private void OnAttackEventHandler(){
            _animator.SetTrigger("Attack");
        }

        private void OnStartReadyBlockAttackEventHandler() {
            _animator.SetBool("ReadyBlockAttack", true);
        }

        private void OnStopReadyBlockAttackEventHandler() {
            _animator.SetBool("ReadyBlockAttack", false);
        }

        private void OnMoveEventHandler(Vector2 inputDirection)
        {
            _currentAnimationBlendVector = Vector2.SmoothDamp(_currentAnimationBlendVector, inputDirection, ref _animationVelocity, _smoothAnimationTime);
            _animator.SetFloat("DirectionRight", inputDirection.x);
            _animator.SetFloat("DirectionForward", inputDirection.y);

            if(inputDirection.magnitude > 0.1f) {
                Vector3 moveDirection
                  = (inputDirection.x * _cameraGameObject.transform.right) + (inputDirection.y * _cameraGameObject.transform.forward);

                _targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                _angle = Mathf.SmoothDampAngle(_gameObjectRoot.transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);


                _gameObjectRoot.transform.rotation = Quaternion.Euler(0f, _angle, 0f);
            }
        }

        private void OnStartRunEventHandler() {
            _animator.SetBool("Run", true);
        }

        private void OnStopRunEventHandler() {
            _animator.SetBool("Run", false);
        }

        private void OnJumpOverObstacleEventHandler() {
            _animator.SetTrigger("JumpOverObstacle");
        }

        private void OnVaultOverObstacleEventHandler() {
            _animator.SetTrigger("VaultOverObstacle");
        }

    }
}


