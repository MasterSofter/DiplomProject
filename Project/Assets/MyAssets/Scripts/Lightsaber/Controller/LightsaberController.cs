using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lightsaber.Model;
using Lightsaber.Viewer;
using Lightsaber.States;

namespace Lightsaber.Controller {
    [RequireComponent(typeof(Animator))]
    public class LightsaberController : MonoBehaviour
    {
        [SerializeField] private GameObject _lightsLaser;
        private LightsaberModel _model;
        private void Start()
        {
            _model = new LightsaberModel(new LightsaberViewer(gameObject.GetComponent<Animator>(), _lightsLaser), LightsaberStates.TurnedOff);
        }
            

        public void LightsaberTurnOnOff() {
            var currentState = _model.GetCurrentState;

            switch (currentState)
            {
                case LightsaberStates.TurnedOn:
                    TurnOff();
                    break;
                case LightsaberStates.TurnedOff:
                    TurnOn();
                    break;
            }


        }

        private void TurnOn() => _model.SetState(States.LightsaberStates.TurnedOn);
        private void TurnOff() => _model.SetState(States.LightsaberStates.TurnedOff);

    }
}

