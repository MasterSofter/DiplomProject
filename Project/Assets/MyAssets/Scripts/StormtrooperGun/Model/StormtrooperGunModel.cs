using System;
using StormtrooperGun.States;
using AISystem.Model;
using AISystem.EventsSystem;

namespace StormtrooperGun.Model {
    public class StormtrooperGunModel
    {
        private StormtrooperGunStates _currentState;
        public StormtrooperGunStates CurrentState => _currentState;

        public StormtrooperGunModel() { }

        public void SetState(StormtrooperGunStates newState){
            _currentState = newState;
        }
    }
}

