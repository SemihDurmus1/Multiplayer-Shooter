using Photon;
using UnityEngine;
using UniRx;
using System.Collections;

namespace TopDownShooter.Network {
    public enum PlayerNetworkState 
    {
        None,
        Offline,
        Connecting,
        Connected,
        JoiningRoom,
        InRoom,
        LeavingRoom
    }

    public class MatchMakingController : PunBehaviour
    {
        private PlayerNetworkState _currentNetworkState = PlayerNetworkState.None;
        public PlayerNetworkState CurrentNetworkState 
        {
            get
            {
                return _currentNetworkState;
            }
            private set
            {
                bool sendEvent = false;
                if (value != _currentNetworkState)
                {
                    sendEvent = true;
                }
                _currentNetworkState = value;
                if (sendEvent)
                {
                    MessageBroker.Default.Publish
                        (new EventPlayerNetworkStateChange(_currentNetworkState));
                }
            }
        }


        public static MatchMakingController Instance;

        private const string _networkVersion = "v1.0";

        private void Awake()
        {
            Instance = this;

            PhotonNetwork.CacheSendMonoMessageTargets(typeof(MatchMakingController));

        }

        private IEnumerator Start()
        {
            CurrentNetworkState = PlayerNetworkState.Offline;

            yield return new WaitForEndOfFrame();

            CurrentNetworkState = PlayerNetworkState.Connecting;

            PhotonNetwork.ConnectUsingSettings(_networkVersion);
        }

        public void CreateRoom()
        {
            CurrentNetworkState = PlayerNetworkState.JoiningRoom;

            PhotonNetwork.CreateRoom(null);
        }

        public void JoinRandomRoom()
        {
            CurrentNetworkState = PlayerNetworkState.JoiningRoom;
            PhotonNetwork.JoinRandomRoom();
        }

        public void LeaveRoom()
        {
            CurrentNetworkState = PlayerNetworkState.LeavingRoom;
            PhotonNetwork.LeaveRoom();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();

            CurrentNetworkState = PlayerNetworkState.InRoom;

            PhotonNetwork.isMessageQueueRunning = false;
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();

            CurrentNetworkState = PlayerNetworkState.Connected;
        }

        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();

            CurrentNetworkState = PlayerNetworkState.Offline;
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();

            CurrentNetworkState = PlayerNetworkState.Connected;

            Debug.Log("Connected to Master");
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();

            Debug.Log("On Joined Lobby");
        }

        public void Settings()
        {
            Debug.Log("Not Ready Yet");
        }
    }
}