using System;
using UnityEngine;
using AISystem.Core;
using Mobs.Stormtrooper.Controller;
using Mobs.Stormtrooper.Model;
using Mobs.Stormtrooper.Viewer;
using AISystem.EventsSystem;

namespace Mobs.Stormtrooper {
    public class Stormtrooper : AICore
    {
        private StormtrooperController _stormtrooperController;
        private StormtrooperViewer _stormtrooperViewer;
        private StormtrooperModel _stormtrooperModel;
        private AIEventsSystem _eventsSystem;

        private void Awake()
        {
            _eventsSystem = new AIEventsSystem();
            _stormtrooperModel = new StormtrooperModel(_eventsSystem);
            _stormtrooperViewer = new StormtrooperViewer(_eventsSystem, _animator, gameObject, _navMeshAgent);
            _stormtrooperController = new StormtrooperController(gameObject, _eventsSystem);
        }
    }
}

