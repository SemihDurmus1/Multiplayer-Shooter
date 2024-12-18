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

        [SerializeField] private TMP_InputField _nameInputField;

        private void Awake()
        {
            UpdateUIWithNetworkState(MatchMakingController.Instance.CurrentNetworkState);
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerNetworkState).AddTo(gameObject);

            _nameInputField.onEndEdit.AddListener(OnEditEnd);
        }

        private void OnEditEnd(string arg0)
        {
            PhotonNetwork.playerName = arg0;
        }

        private void OnPlayerNetworkState(EventPlayerNetworkStateChange obj)
        {
            var networkState = obj.PlayerNetworkState;
            UpdateUIWithNetworkState(networkState);
        }

        private void UpdateUIWithNetworkState(PlayerNetworkState networkState)
        {
            _currentStateText.text =
                            "Connection State: " + networkState.ToString();
            for (int i = 0; i < _networkButtons.Length; i++)
            {
                _networkButtons[i].interactable = networkState == PlayerNetworkState.Connected;
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