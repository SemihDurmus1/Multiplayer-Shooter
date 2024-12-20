using System.Collections.Generic;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        public PlayerStat PlayerStat {  get; private set; }
        public bool IsLocalPlayer { get; set; }

        [SerializeField] private PhotonView[] _photonViewsForOwnership;

        private List<IPlayerStatHolder> _playerStatHolders;

        public PhotonView[] PhotonViews { get { return _photonViewsForOwnership; } }

        public void SetOwnership(PhotonPlayer photonPlayer, int[] allocatedViewIDArray)
        {
            for (int i = 0; i <= _photonViewsForOwnership.Length; i++)
            {
                _photonViewsForOwnership[i].viewID = allocatedViewIDArray[i];
                _photonViewsForOwnership[i].TransferOwnership(photonPlayer);
            }

            PlayerStat = new PlayerStat(photonPlayer.ID);
            IsLocalPlayer = photonPlayer.IsLocal;
        }

        public void RegisterStatHolder(IPlayerStatHolder statHolder)
        {
            _playerStatHolders.Add(statHolder);
        }

        public void UnRegisterStatHolder(IPlayerStatHolder statHolder)
        {
            _playerStatHolders.Remove(statHolder);
        }

    }
}