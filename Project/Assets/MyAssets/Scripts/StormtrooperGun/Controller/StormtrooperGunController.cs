using System;
using UnityEngine;

using StormtrooperGun.States;
using StormtrooperGun.EventsSystem;
using StormtrooperGun.Model;
using StormtrooperGun.Viewer;
using System.Collections;

namespace StormtrooperGun.Controller {
    public class StormtrooperGunController : MonoBehaviour
    {
        [SerializeField] GameObject _bulletPrefub;
        [SerializeField] Transform _transformInstantiateBullet;
        private StormtrooperGunEventsSystem _eventsSystem;
        private StormtrooperModel _model;
        private StormtrooperGunViewer _viewer;

        private int _countShootedBullet = 3;
        private float _timeReload = 1f;
        private float _timeWaitShoot = 0.35f;

        private void Start()
        {
            _eventsSystem = new StormtrooperGunEventsSystem();
            _model = new StormtrooperModel();
            _viewer = new StormtrooperGunViewer(_eventsSystem, _bulletPrefub, _transformInstantiateBullet);
            _model.SetState(StormtrooperGunStates.ReadyShootState);
        }

        public void Shoot() {
            if (_model.CurrentState == StormtrooperGunStates.ReadyShootState)
            {
                _model.SetState(StormtrooperGunStates.ShootState);
                StartCoroutine(Shooting());
            }
        }

        private IEnumerator Shooting()
        {
            for(int i = 0; i < _countShootedBullet; i++) {
                yield return new WaitForSeconds(_timeWaitShoot);
                _eventsSystem.ViewShootEvent?.Invoke();
            }

            StartCoroutine(Reloading());
        }

        private IEnumerator Reloading() {
            _model.SetState(StormtrooperGunStates.ReloadState);
            yield return new WaitForSeconds(_timeReload);
            _model.SetState(StormtrooperGunStates.ReadyShootState);
        }


    }
}

