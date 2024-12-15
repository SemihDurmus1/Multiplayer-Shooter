using Photon;
using UnityEngine;
using UniRx;
using System.Collections;

namespace TopDownShooter.Network {
    public enum PlayerNetworkState { Offline, Connecting, Connected, InRoom}

    public class MatchMakingController : PunBehaviour
    {
        [SerializeField] private float _delayToConnect = 3f;

        public static MatchMakingController Instance;

        private const string _networkVersion = "v1.0";

        private void Awake()
        {
            Instance = this;

            MessageBroker.Default.Publish
                (new EventPlayerNetworkStateChange(PlayerNetworkState.Offline));

        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_delayToConnect);

            MessageBroker.Default.Publish
                (new EventPlayerNetworkStateChange(PlayerNetworkState.Connecting));

            PhotonNetwork.ConnectUsingSettings(_networkVersion);
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();

            MessageBroker.Default.Publish
                (new EventPlayerNetworkStateChange(PlayerNetworkState.InRoom));
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();

            MessageBroker.Default.Publish
                (new EventPlayerNetworkStateChange(PlayerNetworkState.Connected));
        }

        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();

            MessageBroker.Default.Publish
                (new EventPlayerNetworkStateChange(PlayerNetworkState.Offline));
        }

        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(null);
        }

        public void JoinRandomRoom()
        {

        }

        public void Settings()
        {

        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();

            MessageBroker.Default.Publish
                (new EventPlayerNetworkStateChange(PlayerNetworkState.Connected));

            Debug.Log("Connected to Master");
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();

            Debug.Log("On Joined Lobby");

            
        }
    }
}