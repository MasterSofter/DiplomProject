using System;
using UnityEngine;
using StormtrooperGun.EventsSystem;

namespace StormtrooperGun.Viewer {
    public class StormtrooperGunViewer : IDisposable
    {
        private StormtrooperGunEventsSystem _eventsSystem;
        private GameObject _bulletPrefub;
        private Transform _prefubPointInstantiate;
        public StormtrooperGunViewer(StormtrooperGunEventsSystem eventsSystem, GameObject bulletPrefub, Transform prefubPointInstatiate)
        {
            _eventsSystem = eventsSystem;
            _bulletPrefub = bulletPrefub;
            _prefubPointInstantiate = prefubPointInstatiate;
            SubscribeEvents();
        }

        public void Dispose() {
            _eventsSystem = null;
            _bulletPrefub = null;
            _prefubPointInstantiate = null;
        }

        private void SubscribeEvents() {
            _eventsSystem.ViewShootEvent += OnShootEventHandler;
        }

        private void OnShootEventHandler() {
            if(_bulletPrefub != null && _prefubPointInstantiate != null)
            GameObject.Instantiate(_bulletPrefub, _prefubPointInstantiate.position, _prefubPointInstantiate.transform.rotation);
        }
    }
}

