using System;
using System.Collections.Generic;
using UnityEngine;
using AISystem.Controller;
using AISystem.Actions;

namespace Mobs.Stormtrooper.Controller {
    public sealed class StormtrooperThink : AIThink
    {
        private float _distanceToAim = 7;

        public StormtrooperThink(AIAct act, GameObject gameObjectRoot) : base(act, gameObjectRoot)
        {
        }

        public override void Do(GameObject aimGameObject) {
            List<AIAction> actionsList = new List<AIAction>();
            if (aimGameObject != null) {
                actionsList.Add(AIAction.Aim);

                Vector3 directToAim = aimGameObject.transform.position - _gameObjectRoot.transform.position;

                float angle = Mathf.Atan2(directToAim.x, directToAim.z) * Mathf.Rad2Deg;
                if (angle > 0.05f || angle < 0.05f)
                    actionsList.Add(AIAction.Rotate);


                float distance = directToAim.magnitude;
                if (distance > _distanceToAim)
                    actionsList.Add(AIAction.Move);

                _act.Do(actionsList, aimGameObject);
            }
            else {
                actionsList.Add(AIAction.Sleep);
                _act.Do(actionsList);
            }
        }
    }
}

