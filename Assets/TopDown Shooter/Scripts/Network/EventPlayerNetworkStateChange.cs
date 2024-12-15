using UnityEngine;

namespace TopDownShooter.Network
{
    public struct EventPlayerNetworkStateChange
    {
        public PlayerNetworkState PlayerNetworkState;

        public EventPlayerNetworkStateChange(PlayerNetworkState playerNetworkState)
        {
            PlayerNetworkState = playerNetworkState;
        }
    }
}