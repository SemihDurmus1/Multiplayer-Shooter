using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public struct EventPlayerShoot
    {
        public Vector3 Origin;
        public PlayerStat Stat;

        public EventPlayerShoot(Vector3 origin, PlayerStat stat)
        {
            Origin = origin;
            Stat = stat;
        }
    }
}