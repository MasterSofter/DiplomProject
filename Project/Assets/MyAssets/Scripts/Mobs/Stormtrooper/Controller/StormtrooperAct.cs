using System;

using UnityEngine;
using AISystem.Controller;
using AISystem.EventsSystem;
using AISystem.Actions;

using StormtrooperGun.Controller;

namespace Mobs.Stormtrooper.Controller {
    public sealed class StormtrooperAct : AIAct
    {
        StormtrooperGunController _gunController;
        public StormtrooperAct(AIEventsSystem eventsSystem, StormtrooperGunController gunController) : base(eventsSystem)
        {
            _gunController = gunController;
        }

        protected override void Do(AIAction _action, GameObject aimGameObject)
        {

            switch (_action)
            {
                case AIAction.Sleep:
                    _eventsSystem.SleepEvent?.Invoke();
                    break;
                case AIAction.Aim:
                    _eventsSystem.AimEvent?.Invoke(aimGameObject);
                    break;
                case AIAction.Move:
                    _eventsSystem.MoveEvent?.Invoke(aimGameObject);
                    break;
                case AIAction.Rotate:
                    _eventsSystem.RotateEvent?.Invoke(aimGameObject);
                    break;
                case AIAction.Shoot:
                    _gunController.Shoot();
                    break;
 
            }
        }

    }
}

