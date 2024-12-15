using System;
using TMPro;
using TopDownShooter.Network;
using UniRx;
using UnityEngine;

namespace TopDownShooter.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentStateText;


        private void Awake()
        {
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerOnline);
        }

        private void OnPlayerOnline(EventPlayerNetworkStateChange obj)
        {
            _currentStateText.text = 
                "Connection State: " + obj.PlayerNetworkState.ToString();
            //_currentStateText.color = Color.green;
        }

        public void _CreateRoomClick()
        {

        }

        public void _JoinRandomRoomClick()
        {

        }

        public void _SettingsClick()
        {

        }
    }
}