using System.Collections.Generic;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        private bool _initialized = false;
        public PlayerStat PlayerStat {  get; private set; }

        [SerializeField] private PhotonView[] _photonViewsForOwnership;

        private List<IPlayerStatHolder> _playerStatHolders = new();

        public PhotonView[] PhotonViews { get { return _photonViewsForOwnership; } }

        public void SetOwnership(PhotonPlayer photonPlayer, int[] allocatedViewIDArray)
        {
            for (int i = 0; i <= _photonViewsForOwnership.Length; i++)
            {
                _photonViewsForOwnership[i].viewID = allocatedViewIDArray[i];
                _photonViewsForOwnership[i].TransferOwnership(photonPlayer);
            }

            PlayerStat = new PlayerStat(photonPlayer.ID, photonPlayer.IsLocal);
            for (int i = 0; i < _playerStatHolders.Count; i++)
            {
                _playerStatHolders[i].SetStat(PlayerStat);
            }
            _initialized = true;
        }

        public void RegisterStatHolder(IPlayerStatHolder statHolder)
        {
            _playerStatHolders.Add(statHolder);
            if (_initialized)
            {
                statHolder.SetStat(PlayerStat);
            }
        }

        public void UnRegisterStatHolder(IPlayerStatHolder statHolder)
        {
            _playerStatHolders.Remove(statHolder);
        }

    }
}