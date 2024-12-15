using UnityEngine;

namespace TopDownShooter.Network
{
    public struct EventPlayerNetworkStateChange
    {
        public PlayerNetworkState PlayerNetworkState;//Player's state saving in here

        public EventPlayerNetworkStateChange(PlayerNetworkState playerNetworkState)
        {
            PlayerNetworkState = playerNetworkState;
        }
    }
}