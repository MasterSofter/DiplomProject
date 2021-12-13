using System;
using UnityEngine;
using AISystem.Controller;
using AISystem.EventsSystem;

using StormtrooperGun.Controller;

namespace Mobs.Stormtrooper.Controller {
    public sealed class StormtrooperController : AIController
    {
        private AISensor _aiSensor;
        private AIThink _think;
        private AIAct _act;
        private StormtrooperGunController _gunConrtoller;
        

        public StormtrooperController(GameObject gameObjectRoot, AIEventsSystem eventsSystem, StormtrooperGunController gunController)
            : base(gameObjectRoot, eventsSystem)
        {
            _gunConrtoller = gunController;
            _act = new StormtrooperAct(eventsSystem, _gunConrtoller);
            _think = new StormtrooperThink(_act, gameObjectRoot);
            _aiSensor = _gameObjectRoot.AddComponent<AISensor>();

            InitializeControllerComponents();
        }

        private void InitializeControllerComponents() {
            _aiSensor.Init(_think, _gameObjectRoot);
        }
    }
}

