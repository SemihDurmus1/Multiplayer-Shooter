using UnityEngine;

namespace TopDownShooter.Stat
{
    public class DamageableObjectBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private Collider _collider;

        public int InstanceID {  get; private set; }

        private void Awake()
        {
            InstanceID = _collider.GetInstanceID();
            this.InitializeDamageable();
        }

        public void Damage(float damage)
        {
            Debug.Log("U damaged me :'( " + damage);
        }

    }
}