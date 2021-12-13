using System;
using StormtrooperGun.States;

namespace StormtrooperGun.Model {
    public class StormtrooperModel
    {
        private StormtrooperGunStates _currentState;
        public StormtrooperGunStates CurrentState => _currentState;

        public void SetState(StormtrooperGunStates newState) {
            _currentState = newState;
        }
    }
}

