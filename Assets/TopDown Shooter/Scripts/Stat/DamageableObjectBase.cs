using System.Collections;
using TopDownShooter.Inventory;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Stat
{
    public class DamageableObjectBase : MonoBehaviour, IDamageable
    {
        public int InstanceID {  get; private set; }

        [SerializeField] private Collider _collider;

        public PlayerStat PLayerStat { get; set; }

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
                    (dmg.TimeBasedDamage, dmg.TimeBasedDamageDuration, dmg.Stat));
            }
            else
            {
                PLayerStat.Damage(dmg);
            }
        }

        

        IEnumerator TimeBasedDamage(float damage, float totalDuration, PlayerStat playerStat)
        {
            while (totalDuration > 0)
            {
                yield return new WaitForSeconds(1);//Magic Number

                totalDuration -= 1;

                PLayerStat.Damage(damage, playerStat);
            }

        }

        public void SetStat(PlayerStat stat)
        {
            PLayerStat = stat;
        }
    }
}