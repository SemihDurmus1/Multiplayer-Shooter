using UniRx;
using UnityEngine;


namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDownShooter/Inventory/Player Inventory Canon Item Data")]

    public class PlayerInventoryCannonItemData : 
        AbstractPlayerInventoryItemData<PlayerInventoryCannonItemMono>
    {
        [SerializeField] private float _damage;
        public float Damage { get { return _damage; } }

        [SerializeField] private float _rpm = 1f;//Shoot duration
        public float RPM { get { return _rpm; } }

        private float _lastShootTime;

        public override void Initialize(PlayerInventoryController targetPlayerInventory)
        {
            base.Initialize(targetPlayerInventory);
            InstantiateAndInitializePrefab(targetPlayerInventory.Parent);

            targetPlayerInventory.ReactiveShootCommand.Subscribe(OnReactiveShootCommand).
                AddTo(_compositeDisposable);

            Debug.Log("Canon Item Data Class");
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
                _instantiated.Shoot();
                _lastShootTime = Time.time;
            }
            else
            {
                Debug.LogAssertion("U can't shoot now",this);
            }
        }
    }
}