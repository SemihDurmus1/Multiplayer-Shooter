using UniRx;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public abstract class AbstractBasePlayerInventoryItemData : ScriptableObject
    {
        protected PlayerInventoryController _inventoryController;//Its using, ignore the pale gray, and do not delete it.
        protected CompositeDisposable _compositeDisposable;
        public virtual void Initialize(PlayerInventoryController targetPlayerInventory)
        {
            _inventoryController = targetPlayerInventory;
            _compositeDisposable = new CompositeDisposable();
        }


        public virtual void Destroy()
        {
            //means that we are unsubscribing from all the events we add to this
            _compositeDisposable?.Dispose();
            Destroy(this);
        }
    }
}