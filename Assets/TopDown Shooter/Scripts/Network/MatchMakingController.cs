using Photon;
using UnityEngine;
using UniRx;
using System.Collections;

namespace TopDownShooter.Network {
    public enum PlayerNetworkState { Offline, Connecting, Connected, JoiningRoom, InRoom}

    public class MatchMakingController : PunBehaviour
    {
        [SerializeField] private float _delayToConnect = 3f;

        public static MatchMakingController Instance;

        private const string _networkVersion = "v1.0";

        private void Awake()
        {
            Instance = this;



        }

        private IEnumerator Start()
        {
            MessageBroker.Default.Publish
                (new EventPlayerNetworkStateChange(PlayerNetworkState.Offline));

            yield return new WaitForSeconds(_delayToConnect);

            MessageBroker.Default.Publish
                (new EventPlayerNetworkStateChange(PlayerNetworkState.Connecting));

            PhotonNetwork.ConnectUsingSettings(_networkVersion);
        }

        public void CreateRoom()
        {
            MessageBroker.Default.Publish
                (new EventPlayerNetworkStateChange(PlayerNetworkState.JoiningRoom));

            PhotonNetwork.CreateRoom(null);
        }

        public void JoinRandomRoom()
        {
            MessageBroker.Default.Publish
                (new EventPlayerNetworkStateChange(PlayerNetworkState.InRoom));
            PhotonNetwork.JoinRandomRoom();
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




        public void Settings()
        {
            Debug.Log("Not Ready Yet");
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