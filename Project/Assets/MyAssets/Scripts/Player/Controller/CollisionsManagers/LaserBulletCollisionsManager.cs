using UnityEngine;
using System.Collections;
using Player.EventsSystem;

namespace Player.Controller.CollisionsManagers
{
    [RequireComponent(typeof(SphereCollider))]
    public class LaserBulletCollisionsManager : MonoBehaviour
    {
        private PlayerEventsSystem _eventsSystem;

        public void Init(PlayerEventsSystem eventsSystem)
        {
            _eventsSystem = eventsSystem;
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.layer == LayerMask.NameToLayer("LaserBullet"))
                _eventsSystem.LaserBulletDetectedEvent?.Invoke(other.gameObject);
        }

    
    }

}

