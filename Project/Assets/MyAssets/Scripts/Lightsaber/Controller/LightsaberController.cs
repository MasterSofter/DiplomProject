using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lightsaber.Model;
using Lightsaber.Viewer;
using Lightsaber.States;
using Mobs.Stormtrooper;

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

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Stormtrooper"))
            {
                Stormtrooper stormtrooper = other.gameObject.GetComponent<Stormtrooper>();
                if(stormtrooper != null) {
                    stormtrooper?.GetHeathInterface?.SetDamage(_model.Damage);
                }
            }
        }

        public bool LightsaberTurnOnOff() {
            var currentState = _model.GetCurrentState;

            if (currentState == LightsaberStates.TurnedOn)
            {
                TurnOff();
                return false;
            }
            else {
                TurnOn();
                return true;
            } 
        }

        public void LightsaberTurnOn() => TurnOn();
        public void LightsaberTurnOff() => TurnOff();

        private void TurnOn() => _model.SetState(States.LightsaberStates.TurnedOn);
        private void TurnOff() => _model.SetState(States.LightsaberStates.TurnedOff);

    }
}

