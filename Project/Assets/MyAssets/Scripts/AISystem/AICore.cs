using System;
using UnityEngine;
using UnityEngine.AI;

using AISystem.Controller;
using AISystem.Viewer;
using AISystem.Model;
using AISystem.EventsSystem;
namespace AISystem.Core {
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class AICore : MonoBehaviour
    {
        [SerializeField] protected Animator _animator;
        [SerializeField] protected NavMeshAgent _navMeshAgent;
        protected AIEventsSystem _aiEventsSystem;
        protected AIController _aiController;
        protected AIViewer _aiViewer;
        protected AIModel _aiModel;
    }
}

