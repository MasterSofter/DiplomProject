using System;
using System.Collections.Generic;
using UnityEngine;
using AISystem.Controller;
using AISystem.Actions;
using AISystem.Model;

namespace Mobs.Stormtrooper.Controller {
    public sealed class StormtrooperThink : AIThink
    {
        private float _distanceToAim = 7;
        private AIModel _model;

        public StormtrooperThink(AIAct act, AIModel model ,GameObject gameObjectRoot) : base(act, gameObjectRoot)
        {
            _model = model;
        }

        public void Dispose(){
            base.Dispose();
            _model.Dispose();
            _model = null;
        }

        public override void Do(GameObject aimGameObject) {
            List<AIAction> actionsList = new List<AIAction>();

            //если видит цель
            if (aimGameObject != null) {

                if (_model.IsDead) return;
                // если еще жив
                if (_model.CurrentHealth == 0 && !_model.IsDead) {
                    _model.IsDead = true;
                    actionsList.Add(AIAction.Die);
                    _act.Do(actionsList);
                    return;
                }

                actionsList.Add(AIAction.Aim);       //добавляем в список задач - прицеливание

                Vector3 directToAim = aimGameObject.transform.position - _gameObjectRoot.transform.position;

                float angle = Mathf.Atan2(directToAim.x, directToAim.z) * Mathf.Rad2Deg;
                if (angle > 0.05f || angle < 0.05f)
                    actionsList.Add(AIAction.Rotate); //добавляем в список задач - поворот 


                float distance = directToAim.magnitude;
                if (distance > _distanceToAim)
                    actionsList.Add(AIAction.Move);  //добавляем в список задач - перемещение

                actionsList.Add(AIAction.Shoot);     //добавляем в список задач - стрельба

                _act.Do(actionsList, aimGameObject);
            }
            else {
                //иначе если цели не видит
                actionsList.Add(AIAction.Sleep);
                _act.Do(actionsList);
            }
        }
    }
}

