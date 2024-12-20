using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryCannonItemMono : AbstractPlayerInventoryItemMono
    {
        [SerializeField] private Transform _cannonShootPoint;

        public void Shoot(IDamage damage, int shooterID)
        {
            ScriptableShootManager.Instance.Shoot(_cannonShootPoint.position, _cannonShootPoint.forward, damage, shooterID);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_cannonShootPoint.position, .10f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_cannonShootPoint.position, _cannonShootPoint.position + _cannonShootPoint.forward * 100);
        }
    }
}