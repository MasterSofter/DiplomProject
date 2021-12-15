using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using AISystem.Actions;
namespace AISystem.Controller {
    /// <summary>
    /// Является логическим блоком, который принимает решения и
    /// выдает на выходе список задач, которые должен выполнить AIAct
    /// </summary>
    public class AIThink : IDisposable
    {
        protected AIAct _act;
        protected Vector3 _directionToAim;
        protected GameObject _gameObjectRoot;


        public AIThink(AIAct act, GameObject gameObjectRoot)
        {
            _gameObjectRoot = gameObjectRoot;
            _act = act;
            _directionToAim = new Vector3();
        }

        public void Dispose()
        {
            _act = null;
            _gameObjectRoot = null;
        }
        public virtual void Do(GameObject aimGameObject){}
    }
}

