using System;
using AISystem.Model;
using AISystem.EventsSystem;
using Mobs.Stormtrooper.Interfaces;
namespace Mobs.Stormtrooper.Model {
    public sealed class StormtrooperModel : AIModel, IHealth
    {
        public void SetDamage(float damage) {
            _health -= damage;
            if(_health < 0){
                _health = 0;
                _isDead = true;
            }
        }

        public StormtrooperModel(AIEventsSystem aiEventsSystem) : base (aiEventsSystem)
        {
        }
    }
}

