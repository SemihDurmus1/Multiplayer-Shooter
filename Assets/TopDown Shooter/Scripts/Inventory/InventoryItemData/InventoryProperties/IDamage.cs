namespace TopDownShooter.Inventory
{
    public interface IDamage
    {
        public float Damage { get; }
        public float ArmorPenetration { get; }

        float TimeBasedDamage { get; }
        float TimeBasedDamageDuration {  get; }
    }
}