using TopDownShooter.Stat;
using UnityEditor;

namespace TopDownShooter.Inventory
{
    public interface IDamage
    {
        public float Damage { get; }
        public float ArmorPenetration { get; }

        float TimeBasedDamage { get; }
        float TimeBasedDamageDuration {  get; }

        PlayerStat Stat { get; }
    }
}