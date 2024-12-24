using TopDownShooter.Inventory;
using TopDownShooter.Network;
using TopDownShooter.Stat;
using UniRx;
using UnityEngine;


namespace TopDownShooter
{
    public class PlayerController : MonoBehaviour, IPlayerStatHolder
    {
        [SerializeField] private DamageableObjectBase[] _damageableObjectBases;
        
        [SerializeField] private  NetworkPlayer _networkPlayer;
        [SerializeField] protected PlayerInventoryController _inventoryController;

        public PlayerStat playerStat {  get; set; }

        protected void Start()
        {
            _networkPlayer.RegisterStatHolder(_inventoryController);
            _networkPlayer.PlayerStat.OnDeath.Subscribe(OnDeath).AddTo(gameObject);

            for (int i = 0; i < _damageableObjectBases.Length; i++)
            {
                _networkPlayer.RegisterStatHolder(_damageableObjectBases[i].PLayerStat);
            }
            _networkPlayer.RegisterStatHolder(this);
        }

        public void SetStat(PlayerStat stat)
        {
            playerStat = stat;

            stat.OnDeath.Subscribe(OnDeath).AddTo(gameObject);
        }

        private void OnDeath(Unit unit)
        {
            if (_networkPlayer.PlayerStat.IsLocalPlayer)
            {
                MatchMakingController.Instance.LeaveRoom();
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}