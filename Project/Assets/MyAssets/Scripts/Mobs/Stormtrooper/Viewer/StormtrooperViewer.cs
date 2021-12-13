using System;
using UnityEngine;
using UnityEngine.AI;
using AISystem.EventsSystem;
using AISystem.Viewer;

namespace Mobs.Stormtrooper.Viewer {
    public sealed class StormtrooperViewer : AIViewer
    {
        private float _turnSmoothTime = 0.01f;
        private float _turnSmoothVelocity;
        private float _targetAngle, _angle;

        public StormtrooperViewer(AIEventsSystem eventsSystem, Animator animator, GameObject gameObjectRoot, NavMeshAgent navMeshAgent)
            : base(eventsSystem, animator, gameObjectRoot, navMeshAgent)
        {
        }

        protected override void OnSleepEventHandler(){
            _animator.SetBool("Move", false);
            _animator.SetBool("Aim", false);
        }

        protected override void OnAimEventHandler(GameObject aimGameObject) {
            _animator.SetBool("Move", false);
            _animator.SetBool("Aim", true);
        }

        protected override void OnMoveEventHandler(GameObject aimGameObject)
        {
            _animator.SetBool("Move", true);
        }
        protected override void OnRotateEventHandler(GameObject aimGameObject)
        {
            _gameObjectRoot.transform.rotation = CalculateViewDirection(aimGameObject);
        }

        private Quaternion CalculateViewDirection(GameObject aimGameObject)
        {
            //Определить направление движения
            _navMeshAgent.SetDestination(aimGameObject.transform.position);
            Vector3 vecDirection = (_navMeshAgent.steeringTarget - _gameObjectRoot.transform.position).normalized;

            _targetAngle = Mathf.Atan2(vecDirection.x, vecDirection.z) * Mathf.Rad2Deg;
            _angle = Mathf.SmoothDampAngle(_gameObjectRoot.transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

            return Quaternion.Euler(0f, _angle, 0f);
        }
    }
}

