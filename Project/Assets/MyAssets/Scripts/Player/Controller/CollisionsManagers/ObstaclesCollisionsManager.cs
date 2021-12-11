using UnityEngine;
using System.Collections;

using Player.EventsSystem;
namespace Player.Controller.CollisionsManagers {
    [RequireComponent(typeof(SphereCollider))]
    public class ObstaclesCollisionsManager : MonoBehaviour
    {
        private PlayerEventsSystem _eventsSystem;

        public void Init(PlayerEventsSystem eventsSystem) {
            _eventsSystem = eventsSystem;
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
                _eventsSystem.ObstacleDetectedEvent?.Invoke(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
                _eventsSystem.ObstacleMissedEvent?.Invoke(other.gameObject);
        }
    }
}

