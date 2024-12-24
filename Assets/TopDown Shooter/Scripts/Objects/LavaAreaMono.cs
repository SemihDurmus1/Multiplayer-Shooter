using TopDownShooter.Inventory;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Objects
{
    public class LavaAreaMono : MonoBehaviour, IDamage
    {
        [SerializeField] private float _damage;
        public float Damage { get { return _damage; } }


        [Range(0.1f, 2)]
        [SerializeField] private float _armorPenetration = 3f;
        public float ArmorPenetration { get { return _armorPenetration; } }


        [Header("Time Base Damage")]
        [SerializeField] private float _timeBasedDamage = 3f;
        public float TimeBasedDamage { get { return _timeBasedDamage; } }
        [SerializeField] private float _timeBasedDamageDuration = 3f;
        public float TimeBasedDamageDuration { get { return _timeBasedDamageDuration; } }

        public PlayerStat Stat { get { return null; } }

        private void OnTriggerEnter(Collider collider)
        {
            int colliderInstanceID = collider.GetInstanceID();

            if (DamageableHelper.DamageableList.ContainsKey(colliderInstanceID))
            {
                DamageableHelper.DamageableList[colliderInstanceID].Damage(this);
            }
        }
    }
}