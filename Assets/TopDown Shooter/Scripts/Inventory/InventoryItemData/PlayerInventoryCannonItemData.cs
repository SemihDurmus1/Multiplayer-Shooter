using UniRx;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDownShooter/Inventory/Player Inventory Canon Item Data")]

    public class PlayerInventoryCannonItemData : AbstractPlayerInventoryItemData<PlayerInventoryCannonItemMono>, IDamage
    {
        private float _lastShootTime;

        [SerializeField] private float _damage;
        public float Damage { get { return _damage; } }


        [SerializeField] private float _rpm = 1f;//Shoot duration
        public float RPM { get { return _rpm; } }


        [Range(0.1f, 2)]
        [SerializeField] private float _armorPenetration = 3f;
        public float ArmorPenetration { get { return _armorPenetration; } }

        [Header("Time Base Damage")]
        [SerializeField] private float _timeBasedDamage = 3f;
        public float TimeBasedDamage { get { return TimeBasedDamage; } }


        [SerializeField] private float _timeBasedDamageDuration = 3f;
        public float TimeBasedDamageDuration { get { return _timeBasedDamageDuration; } }


        


        public override void Initialize(PlayerInventoryController targetPlayerInventory)
        {
            base.Initialize(targetPlayerInventory);
            InstantiateAndInitializePrefab(targetPlayerInventory.CannonParent);

            targetPlayerInventory.ReactiveShootCommand.Subscribe(OnReactiveShootCommand).
                AddTo(_compositeDisposable);

            //Debug.Log("Canon Item Data Class");
        }


        public override void Destroy()
        {
            base.Destroy();
        }
        private void OnReactiveShootCommand(Unit unit)
        {
            Debug.Log("Reactive Command Shoot!");
            Shoot();
        }

        public void Shoot()
        {
            Debug.Log("Shoot Started");
            if (Time.time - _lastShootTime > _rpm)
            {
                _instantiated.Shoot(this);
                _lastShootTime = Time.time;
            }
            else
            {
                Debug.LogWarning("U can't shoot now",this);
            }
        }
    }
}