using System;
using UnityEngine;

using StormtrooperGun.States;
using StormtrooperGun.EventsSystem;
using StormtrooperGun.Model;
using StormtrooperGun.Viewer;
using System.Collections;

namespace StormtrooperGun.Controller {
    public class StormtrooperGunController : MonoBehaviour, IDisposable
    {
        [SerializeField] GameObject _bulletPrefub;
        [SerializeField] Transform _transformInstantiateBullet;
        private StormtrooperGunEventsSystem _eventsSystem;
        private StormtrooperGunModel _model;
        private StormtrooperGunViewer _viewer;

        private int _countShootedBullet = 3;
        private float _timeReload = 1f;
        private float _timeWaitShoot = 0.35f;


        public void Dispose()
        {
            GameObject.Destroy(this);

            _viewer.Dispose();
            _viewer = null;
            _eventsSystem = null;
            _bulletPrefub = null;
            _transformInstantiateBullet = null;
            _model = null;

        }

        private void Start()
        {
            _eventsSystem = new StormtrooperGunEventsSystem();
            _model = new StormtrooperGunModel();
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
                if(_eventsSystem != null)
                    _eventsSystem.ViewShootEvent?.Invoke();
                else
                    StopCoroutine(Shooting());
            }

            StartCoroutine(Reloading());
        }

        private IEnumerator Reloading() {
            if (_model != null)
                _model.SetState(StormtrooperGunStates.ReloadState);
            else
                StopCoroutine(Reloading());
            yield return new WaitForSeconds(_timeReload);
            if(_model != null)
                _model.SetState(StormtrooperGunStates.ReadyShootState);

        }
    }
}

