using System.Collections.Generic;
using TopDownShooter.Inventory;


namespace TopDownShooter.Stat
{
    public static class DamageableHelper
    {
        public static Dictionary<int, IDamageable> DamageableList = new Dictionary<int, IDamageable>();
        public static void InitializeDamageable(this IDamageable damageable)
        {
            DamageableList.Add(damageable.InstanceID, damageable);
        }


        //This method removes the objects InstanceID
        public static void DestroyDamageable(this IDamageable damageable)
        {
            DamageableList.Remove(damageable.InstanceID);
        }
    }

    public interface IDamageable
    {
        public int InstanceID { get; }
        public void Damage(IDamage dmg);
    }
}