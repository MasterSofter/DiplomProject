using System;
using UnityEngine;
using UnityEngine.AI;

using AISystem.EventsSystem;
namespace AISystem.Viewer {
    /// <summary>
    /// Реализует задачу визуализации действий ИИ
    /// </summary>
    public class AIViewer : IDisposable
    {
        protected NavMeshAgent _navMeshAgent;
        protected GameObject _gameObjectRoot;
        protected AIEventsSystem _eventsSystem;
        protected Animator _animator;

        public AIViewer(AIEventsSystem eventsSystem, Animator animator, GameObject gameObjectRoot, NavMeshAgent navMeshAgent){
            _navMeshAgent = navMeshAgent;
            _gameObjectRoot = gameObjectRoot;
            _animator = animator;
            _eventsSystem = eventsSystem;
            SubscribeEvents();
        }

        public void Dispose() {
           
            _gameObjectRoot = null;
            _eventsSystem = null;
            _animator = null;

            GameObject.Destroy(_navMeshAgent);
            _navMeshAgent = null;

        }

        private void SubscribeEvents() {
            _eventsSystem.SleepEvent += OnSleepEventHandler;
            _eventsSystem.MoveEvent += OnMoveEventHandler;
            _eventsSystem.RotateEvent += OnRotateEventHandler;
            _eventsSystem.AimEvent += OnAimEventHandler;
            _eventsSystem.DieEvent += OnDieEventHandler;
        }
        protected virtual void OnAimEventHandler(GameObject aimGameObject) {}
        protected virtual void OnDieEventHandler() {}
        protected virtual void OnSleepEventHandler() {}
        protected virtual void OnMoveEventHandler(GameObject aimGameObject) {}
        protected virtual void OnRotateEventHandler(GameObject aimGameObject) {}
    }
}

