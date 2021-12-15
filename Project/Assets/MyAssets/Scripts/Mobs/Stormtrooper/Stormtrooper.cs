using System;
using UnityEngine;
using AISystem.Core;
using Mobs.Stormtrooper.Controller;
using Mobs.Stormtrooper.Model;
using Mobs.Stormtrooper.Viewer;
using AISystem.EventsSystem;
using StormtrooperGun.Controller;
using AISystem.Model;
using Mobs.Stormtrooper.Interfaces;
using AISystem.Controller;
using UnityEngine;

namespace Mobs.Stormtrooper {
    public class Stormtrooper : AICore
    {
        [SerializeField] private StormtrooperGunController _gunController;
        private StormtrooperController _stormtrooperController;
        private StormtrooperViewer _stormtrooperViewer;
        private AIEventsSystem _eventsSystem;
        private StormtrooperModel _stormtrooperModel;


        public IHealth GetHeathInterface => (IHealth)_stormtrooperModel;
        private void SubscribeEvents() => _eventsSystem.DieEvent += OnDieEventHandeler;

        private void OnDieEventHandeler()
        {
            GameObject.Destroy(this);

            _stormtrooperController.Dispose();
            _stormtrooperViewer.Dispose();
            _stormtrooperModel.Dispose();
            _gunController.Dispose();

            _gunController = null;
            _eventsSystem = null;
            _stormtrooperController = null;
            _stormtrooperModel = null;
        }



        private void Awake()
        {
            _eventsSystem = new AIEventsSystem();
            _stormtrooperModel = new StormtrooperModel(_eventsSystem);
            _stormtrooperViewer = new StormtrooperViewer(_eventsSystem, _animator, gameObject, _navMeshAgent);
            _stormtrooperController = new StormtrooperController(gameObject, _stormtrooperModel, _eventsSystem, _gunController);
            SubscribeEvents();
        }
    }
}

