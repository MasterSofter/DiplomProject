using System;
using UnityEngine;
using AISystem.Controller;
using AISystem.EventsSystem;

namespace Mobs.Stormtrooper.Controller {
    public sealed class StormtrooperController : AIController
    {
        public StormtrooperController(GameObject gameObjectRoot, AIEventsSystem eventsSystem)
            : base(gameObjectRoot, eventsSystem, new StormtrooperAct(eventsSystem), new StormtrooperThink(new StormtrooperAct(eventsSystem), gameObjectRoot))
        {

        }
    }
}

