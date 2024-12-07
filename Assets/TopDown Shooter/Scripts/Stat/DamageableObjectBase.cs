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

            if (Armor > 0)
            {
                Armor -= (dmg.Damage * dmg.ArmorPenetration);
            }
            else
            {
                Health -= dmg.Damage;

                Health += Armor;
                Debug.Log(gameObject.name + " damaged " + dmg + " current health: " + Health);

                if (Health <= 0)
                {
                    Destroy();

                }
            }
        }



    }
}