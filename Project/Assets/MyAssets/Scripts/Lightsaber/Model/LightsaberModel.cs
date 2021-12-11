using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lightsaber.States;
using Lightsaber.Viewer;
namespace Lightsaber.Model {
    public class LightsaberModel 
    {
        private LightsaberStates _currentState;
        private LightsaberViewer _viewer;

        public LightsaberModel(LightsaberViewer viewer, LightsaberStates beinState){
            _viewer = viewer;
            SetState(beinState);
        }

        public void SetState(LightsaberStates newState) {
            _currentState = newState;
            _viewer.ViewCurrentState(_currentState);
        }

        public LightsaberStates GetCurrentState => _currentState;
           
    }
}

