using System;
using UnityEngine;

using AISystem.EventsSystem;

namespace AISystem.Model {
    /// <summary>
    /// Модель данных ИИ
    /// </summary>
    public class AIModel
    {
        protected float _health;
        protected AIEventsSystem _aiEventsSystem;
        public AIModel(AIEventsSystem aiEventsSystem)
        {
            _health = 100;
            _aiEventsSystem = aiEventsSystem;

            SubscribeEvents();
        }

        private void SubscribeEvents() {

        }
    }
}

