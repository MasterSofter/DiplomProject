using System;
using UnityEngine;

using AISystem.EventsSystem;

namespace AISystem.Model {
    /// <summary>
    /// Модель данных ИИ
    /// </summary>
    public class AIModel : IDisposable
    {
        protected bool _isDead;
        protected float _health;

        public bool IsDead {
            set { _isDead = value; }
            get { return _isDead; }
        }
        public float CurrentHealth => _health;
        protected AIEventsSystem _eventSystem;

        public AIModel(AIEventsSystem eventSystem)
        {
            _isDead = false;
            _health = 100;
            _eventSystem = eventSystem;
        }

        public void Dispose() {
            _eventSystem = null;
        }

    }
}

