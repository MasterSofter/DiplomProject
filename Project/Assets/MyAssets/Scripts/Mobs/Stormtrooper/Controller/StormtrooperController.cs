using System;
using UnityEngine;
using AISystem.Controller;
using AISystem.EventsSystem;
using AISystem.Model;
using UnityEngine.AI;

using StormtrooperGun.Controller;

namespace Mobs.Stormtrooper.Controller {
    public sealed class StormtrooperController : AIController, IDisposable
    {
        private AISensor _aiSensor;
        private AIThink _think;
        private AIAct _act;
        

        public StormtrooperController(GameObject gameObjectRoot, AIModel model ,AIEventsSystem eventsSystem, StormtrooperGunController gunController)
            : base(gameObjectRoot, eventsSystem)
        {
            _act = new StormtrooperAct(eventsSystem, gunController);
            _think = new StormtrooperThink(_act, model, gameObjectRoot);
            _aiSensor = _gameObjectRoot.AddComponent<AISensor>();

            InitializeControllerComponents();
        }

        public void Dispose() {
            base.Dispose();
            GameObject.Destroy(_aiSensor);
            _aiSensor = null;

            _think = null;
            _act = null;
    }

        private void InitializeControllerComponents() => _aiSensor.Init(_think, _gameObjectRoot);
    }
}

