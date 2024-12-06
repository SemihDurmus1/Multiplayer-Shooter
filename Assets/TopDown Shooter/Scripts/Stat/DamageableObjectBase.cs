using UnityEngine;

namespace TopDownShooter.Stat
{
    public class DamageableObjectBase : MonoBehaviour, IDamageable
    {
        public int InstanceID {  get; private set; }

        [SerializeField] private Collider _collider;
        public float Health = 100;

        private Vector3 _defaultScale;

        protected void Awake()
        {
            InstanceID = _collider.GetInstanceID();
            this.InitializeDamageable();

            _defaultScale = transform.lossyScale;
        }

        private void Update()
        {
            transform.localScale = Vector3.Lerp(transform.localScale, (Health / 50) * _defaultScale, Time.deltaTime);
        }

        public virtual void Damage(float damage)
        {
            Health -= damage;
            Debug.Log(gameObject.name + " damaged " + damage + " current health: " + Health);

            if (Health <= 0)
            {
                Destroy();

            }
        }

        protected virtual void Destroy()//Remove the object's InstanceID from dictionary
        {
            this.DestroyDamageable();
            Destroy(gameObject);
        }

    }
}