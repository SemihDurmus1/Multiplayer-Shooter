using System.Collections.Generic;
using TopDownShooter.Stat;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryController : MonoBehaviour, IPlayerStatHolder
    {
        [SerializeField] private AbstractBasePlayerInventoryItemData[] _inventoryItemDataArray;
        private List<AbstractBasePlayerInventoryItemData> _instantiatedItemDataList;

        public Transform BodyParent;
        public Transform CannonParent;

        public ReactiveCommand ReactiveShootCommand { get; private set; }

        public PlayerStat playerStat { get; private set; }

        private void Start()
        {
            //FOR TESTING PURPOSES ONLY
            InitializeInventory(_inventoryItemDataArray);
        }
        private void OnDestroy()
        {
            ClearInventory();
        }

        public void InitializeInventory(AbstractBasePlayerInventoryItemData[] inventoryItemDataArray)
        {
            //adjusting reactive command
            ReactiveShootCommand?.Dispose();//this question mark is a null conditional operator.
            //For forbid any null exceptions

            ReactiveShootCommand = new ReactiveCommand();

            //clears old inventory and creates a new one
            ClearInventory();
            _instantiatedItemDataList = new List
                <AbstractBasePlayerInventoryItemData>(inventoryItemDataArray.Length);

            for (int i = 0; i < inventoryItemDataArray.Length; i++)
            {
                var instantiated = Instantiate(inventoryItemDataArray[i]);

                instantiated.Initialize(this);
                _instantiatedItemDataList.Add(instantiated);
            }
        }

        private void ClearInventory()
        {
            if (_instantiatedItemDataList != null)
            {
                for (int i = 0; i < _instantiatedItemDataList.Count; i++)
                {
                    _instantiatedItemDataList[i].Destroy();
                }
            }
        }

        public void SetStat(PlayerStat stat)
        {
            playerStat = stat;
        }
    }
}