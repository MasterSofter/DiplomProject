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
        
        public AIController(GameObject gameObjectRoot, AIEventsSystem eventsSystem)
        {
            _gameObjectRoot = gameObjectRoot;
            _eventsSystem = eventsSystem;
        }
    }
}

