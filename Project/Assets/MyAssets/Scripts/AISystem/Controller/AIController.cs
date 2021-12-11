using System;
using UnityEngine;
using AISystem.EventsSystem;
namespace AISystem.Controller {
    /// <summary>
    /// Реализует задачу управления ИИ
    /// </summary>
    public class AIController
    {
        protected GameObject _gameObjectRoot;
        protected AIEventsSystem _eventsSystem;

        protected AISensor _aiSensor;
        protected AIThink _aiThink;
        protected AIAct _aiAct;
        

        public AIController(GameObject gameObjectRoot, AIEventsSystem eventsSystem, AIAct aiAct, AIThink aiThink)
        {
            _gameObjectRoot = gameObjectRoot;
            _eventsSystem = eventsSystem;
            _aiAct = aiAct;
            _aiThink = aiThink;
            _aiSensor = _gameObjectRoot.AddComponent<AISensor>();

            InitializeControllerComponents();
        }

        private void InitializeControllerComponents() {
            _aiSensor.Init(_aiThink, _gameObjectRoot);
        }
    }
}

