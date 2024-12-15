using UnityEngine;
using TopDownShooter.Network;
using UniRx;
using UnityEngine.SceneManagement;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "TopDownShooter/Manager/ScriptableSceneManager")]
    public class ScriptableSceneManager : AbstractScriptableManager<ScriptableSceneManager>
    {
        [SerializeField] private string _menuScene;
        [SerializeField] private string _gameScene;

        public override void Initialize()
        {
            base.Initialize();
            SceneManager.LoadScene(_menuScene);
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerNetworkState).AddTo(_compositeDisposable);
        }


        public override void Destroy()
        {
            base.Destroy();
        }
        private void OnPlayerNetworkState(EventPlayerNetworkStateChange obj)
        {
            //When network state change
            Debug.Log("Network State Change on Scene Manager To: " + obj.PlayerNetworkState);

            switch (obj.PlayerNetworkState)
            {
                case PlayerNetworkState.Offline:
                    break;

                case PlayerNetworkState.Connecting:
                    break;

                case PlayerNetworkState.Connected:
                    break;

                case PlayerNetworkState.JoiningRoom:
                    break;

                case PlayerNetworkState.InRoom:
                    SceneManager.LoadScene(_gameScene);
                    break;

                default: break;
            }
        }
    }
}