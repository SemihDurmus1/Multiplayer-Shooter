using UnityEngine;

namespace TopDownShooter.Inventory
{
    public struct EventPlayerShoot
    {
        public Vector3 Origin;
        public int ShooterID;

        public EventPlayerShoot(Vector3 origin, int shooterID)
        {
            Origin = origin;
            ShooterID = shooterID;
        }
    }
}