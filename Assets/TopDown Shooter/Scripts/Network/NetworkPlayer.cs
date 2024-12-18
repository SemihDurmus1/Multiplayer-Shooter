using UnityEngine;

namespace TopDownShooter.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        [SerializeField] private PhotonView[] _photonViewsForOwnership;

        public PhotonView[] PhotonViews { get { return _photonViewsForOwnership; } }

        public void SetOwnership(PhotonPlayer photonPlayer, int[] allocatedViewIDArray)
        {
            for (int i = 0; i <= _photonViewsForOwnership.Length; i++)
            {
                _photonViewsForOwnership[i].viewID = allocatedViewIDArray[i];
                _photonViewsForOwnership[i].TransferOwnership(photonPlayer);
            }
        }
    }
}