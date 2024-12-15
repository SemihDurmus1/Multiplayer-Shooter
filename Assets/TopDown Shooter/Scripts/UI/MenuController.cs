using System;
using TMPro;
using TopDownShooter.Network;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownShooter.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentStateText;
        [SerializeField] private Button[] _networkButtons;
        


        private void Awake()
        {
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerNetworkState).AddTo(gameObject);
        }

        private void OnPlayerNetworkState(EventPlayerNetworkStateChange obj)
        {
            _currentStateText.text = 
                "Connection State: " + obj.PlayerNetworkState.ToString();
            for (int i = 0; i < _networkButtons.Length; i++)
            {
                _networkButtons[i].interactable = obj.PlayerNetworkState == PlayerNetworkState.Connected;
            }
        }

        public void _CreateRoomClick()
        {
            MatchMakingController.Instance.CreateRoom();
        }

        public void _JoinRandomRoomClick()
        {
            MatchMakingController.Instance.JoinRandomRoom();
        }

        public void _SettingsClick()
        {
            MatchMakingController.Instance.Settings();
        }
    }
}