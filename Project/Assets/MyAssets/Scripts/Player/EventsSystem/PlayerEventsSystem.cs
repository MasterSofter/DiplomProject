using System;
using UnityEngine;

namespace Player.EventsSystem {
    public class PlayerEventsSystem
    {
        public Action<GameObject> ObstacleDetectedEvent;
        public Action<GameObject> ObstacleMissedEvent;

        /**************************************************
         *              События для Viewer
         * - события должны относиться только к отображению
         **************************************************/

        public Action<Vector2> ViewMoveEvent;
        public Action ViewStartRunEvent;
        public Action ViewStopRunEvent;
        public Action ViewJumpOverObstacleEvent;
        public Action ViewVaultOverObstacleEvent;
        public Action ViewStartReadyBlockAttackEvent;
        public Action ViewStopReadyBlockAttackEvent;
    }
}


