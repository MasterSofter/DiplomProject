using System;
using UnityEngine;

namespace AISystem.EventsSystem {
    public class AIEventsSystem
    {
        public Action DieEvent;
        public Action SleepEvent;
        public Action<GameObject> AimEvent;
        public Action<GameObject> MoveEvent;
        public Action<GameObject> RotateEvent;
    }
}

