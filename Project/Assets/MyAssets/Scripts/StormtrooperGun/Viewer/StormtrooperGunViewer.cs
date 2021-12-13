using System;
using UnityEngine;
using StormtrooperGun.EventsSystem;

namespace StormtrooperGun.Viewer {
    public class StormtrooperGunViewer
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



        private void SubscribeEvents() {
            _eventsSystem.ViewShootEvent += OnShootEventHandler;
        }

        private void OnShootEventHandler() {
            if(_bulletPrefub != null && _prefubPointInstantiate != null)
            GameObject.Instantiate(_bulletPrefub, _prefubPointInstantiate.position, _prefubPointInstantiate.transform.rotation);
        }
    }
}

