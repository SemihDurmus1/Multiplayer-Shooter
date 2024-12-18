using System;
using UniRx;
using UnityEngine;


namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDownShooter/Inventory/ScriptableEffectManager")]
    public class ScriptableEffectManager : AbstractScriptableManager<ScriptableEffectManager>
    {
        [SerializeField] private GameObject _playerShootEffect;

        public override void Initialize()
        {
            base.Initialize();

            MessageBroker.Default.Receive<EventPlayerShoot>().
                Subscribe(OnPlayerShoot).AddTo(_compositeDisposable);
        }

        private void OnPlayerShoot(EventPlayerShoot obj)
        {
            Instantiate(_playerShootEffect, obj.Origin, Quaternion.identity);
        }
    }
}