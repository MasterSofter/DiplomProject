using System;

using Player.EventsSystem;
namespace Player.Model {
    public class PlayerModel
    {
        private PlayerEventsSystem _eventsSystem;


        public PlayerModel(PlayerEventsSystem eventsSystem)
        {
            _eventsSystem = eventsSystem;
        }

    }
}


