using System.Collections;
using TopDownShooter.Inventory;
using UnityEngine;

namespace TopDownShooter.Stat
{
    public class DamageableObjectBase : MonoBehaviour, IDamageable
    {
        public int InstanceID {  get; private set; }

        [SerializeField] private Collider _collider;

        
        public float Health = 100;
        public float Armor = 20;

        private Vector3 _defaultScale;

        private bool _isDead;

        protected void Awake()
        {
            InstanceID = _collider.GetInstanceID();
            this.InitializeDamageable();

            _defaultScale = transform.lossyScale;
        }

        protected virtual void Destroy()//Remove the object's InstanceID from dictionary
        {
            this.DestroyDamageable();
            Destroy(gameObject);
        }

        public virtual void Damage(IDamage dmg)
        {
            if (dmg.TimeBasedDamage > 0)
            {
                StartCoroutine(TimeBasedDamage
                    (dmg.TimeBasedDamage, dmg.TimeBasedDamageDuration));
            }
            if (Armor > 0)
            {
                Armor -= (dmg.Damage * dmg.ArmorPenetration);
            }
            else
            {
                Health -= dmg.Damage;

                Health += Armor;
                //Debug.Log(gameObject.name + " damaged " + dmg.Damage + " current health: " + Health);
                CheckHealth();
            }
        }

        private void CheckHealth()
        {
            if (_isDead)
            {
                return;
            }
            if (Health <= 0)
            {
                StopAllCoroutines();
                _isDead = true;
                //OnDeath.Execute();
                Destroy();
            }
        }

        IEnumerator TimeBasedDamage(float damage, float totalDuration)
        {
            while (totalDuration > 0)
            {
                yield return new WaitForSeconds(1);//Magic Number

                totalDuration -= 1;
                Health -= damage;

                CheckHealth();
            }

        }
    }
}