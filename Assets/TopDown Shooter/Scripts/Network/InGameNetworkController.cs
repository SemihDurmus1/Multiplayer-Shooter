using System;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Network
{
    public enum InGameNetworkState { NotReady, Ready }

    public class InGameNetworkController : Photon.PunBehaviour
    {
        [SerializeField] private NetworkPlayer _localPlayerPrefab;
        [SerializeField] private NetworkPlayer _remotePlayerPrefab;

        private InGameNetworkState _inGameNetworkState;

        private void Awake()
        {
            MessageBroker.Default.Receive<EventSceneLoaded>().Subscribe(OnSceneLoaded).AddTo(gameObject);
        }

        private void OnSceneLoaded(EventSceneLoaded obj)
        {
            switch (obj.SceneName)
            {
                case "GameScene":
                    _inGameNetworkState = InGameNetworkState.Ready;
                    PhotonNetwork.isMessageQueueRunning = true;
                    InstantiateLocalPlayer();
                    break;
                default:
                    _inGameNetworkState = InGameNetworkState.NotReady;
                    break;
            }
        }

        public void InstantiateLocalPlayer()
        {
            var instantiated = Instantiate(_localPlayerPrefab);
            int[] allocatedViewIDArray = new int[instantiated.PhotonViews.Length];

            for (int i = 0; i < allocatedViewIDArray.Length; i++)
            {
                allocatedViewIDArray[i] = PhotonNetwork.AllocateSceneViewID();
            }

            instantiated.SetOwnership(PhotonNetwork.player, allocatedViewIDArray);

            photonView.RPC(nameof(RPC_InstantiateLocalPlayer), PhotonTargets.OthersBuffered, allocatedViewIDArray);

            PhotonNetwork.isMessageQueueRunning = true;
        }

        [PunRPC]
        public void RPC_InstantiateLocalPlayer(int[] viewIDArray, PhotonMessageInfo photonMessageInfo)
        {
            var instantiated = Instantiate(_remotePlayerPrefab);

            instantiated.SetOwnership(photonMessageInfo.sender, viewIDArray);
        }
    }
}