using UnityEngine;

namespace TopDownShooter.Inventory
{
    public struct EventPlayerShoot
    {
        public Vector3 Origin;
        public EventPlayerShoot(Vector3 origin)
        {
            Origin = origin;
        }
    }
}