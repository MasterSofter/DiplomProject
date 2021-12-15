using System;

using Player.EventsSystem;
namespace Player.Model {
    public class PlayerModel
    {
        private PlayerEventsSystem _eventsSystem;

        private bool _isReadyBlockAttack = false;

        public bool IsReadyBlockAttack => _isReadyBlockAttack;
        public void SetBoolReadyBlockAttack(bool value) =>
            _isReadyBlockAttack = value;

        public PlayerModel(PlayerEventsSystem eventsSystem)
        {
            _eventsSystem = eventsSystem;
        }

    }
}


