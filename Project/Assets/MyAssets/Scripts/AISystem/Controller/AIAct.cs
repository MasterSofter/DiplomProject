using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AISystem.EventsSystem;
using AISystem.Actions;

namespace AISystem.Controller {
    /// <summary>
    /// Является управляющим блоком, который выполняет список задач,
    /// определенный AIThink
    /// </summary>
    public class AIAct
    {
        protected AIEventsSystem _eventsSystem;

        public  AIAct(AIEventsSystem eventsSystem) {
            _eventsSystem = eventsSystem;
        }

        public virtual void Do(List<AIAction> actions, GameObject aimGameObject)
        {
            foreach (var item in actions)
                Do(item, aimGameObject);
        }

        public virtual void Do(List<AIAction> actions) {
            foreach (var item in actions)
                Do(item);
        }

        protected virtual void Do(AIAction _action) {
            switch (_action)
            {
                case AIAction.Sleep:
                    _eventsSystem.SleepEvent?.Invoke();
                    break;
            }
        }

        protected virtual void Do(AIAction _action, GameObject aimGameObject){

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
            }
        }
    }
}
