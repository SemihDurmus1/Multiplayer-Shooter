using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stat
{
    public static class DamageableHelper
    {
        public static Dictionary<int, IDamageable> DamageableList = new Dictionary<int, IDamageable>();
        public static void InitializeDamageable(this IDamageable damageable)
        {
            DamageableList.Add(damageable.InstanceID, damageable);
        }
    }

    public interface IDamageable
    {
        public int InstanceID { get; }
        public void Damage(float damage);
    }
}