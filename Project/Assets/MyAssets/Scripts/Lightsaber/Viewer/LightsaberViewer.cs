using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lightsaber.States;
namespace Lightsaber.Viewer {
    public class LightsaberViewer 
    {
        private Animator _animator;
        private GameObject _lightsLaser;
        public LightsaberViewer(Animator animator, GameObject lightsLaser) {
            _lightsLaser = lightsLaser;
            _animator = animator;
        }

        public void ViewCurrentState(LightsaberStates state)
        {
            switch (state) {
                case LightsaberStates.TurnedOn:
                    _lightsLaser.active = true;
                    _animator.SetBool("TurnedOn", true);
                    break;
                case LightsaberStates.TurnedOff:
                    _lightsLaser.active = false;
                    _animator.SetBool("TurnedOn", false);
                    break;
            }

        }
    }

}
