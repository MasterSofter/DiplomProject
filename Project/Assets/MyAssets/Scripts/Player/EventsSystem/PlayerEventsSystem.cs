using System;
using UnityEngine;

namespace Player.EventsSystem {
    public class PlayerEventsSystem
    {
        public Action<GameObject> ObstacleDetectedEvent;
        public Action<GameObject> ObstacleMissedEvent;
        public Action<Vector2> MoveEvent;
        public Action StartRunEvent;
        public Action StopRunEvent;
        public Action JumpOverObstacleEvent;
        public Action VaultOverObstacleEvent;
    }
}


