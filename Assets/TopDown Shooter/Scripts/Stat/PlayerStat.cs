using TopDownShooter.Inventory;
using System.Collections;
using UniRx;
using UnityEngine;  

namespace TopDownShooter.Stat
{
    public class PlayerStat : IDamageable, IPlayerStatHolder
    {
        public int ID { get; private set; }

        public int InstanceID { get; private set; } = -1;

        public PlayerStat playerStat { get; set; }

        //public PlayerStat IPlayerStatHolder.PlayerStat { get; }

        public ReactiveProperty<float> Health = new ReactiveProperty<float>(100);
        public ReactiveProperty<float> Armor = new ReactiveProperty<float>(100);
        public ReactiveCommand OnDeath = new ReactiveCommand();

        private bool _isDead;

        public PlayerStat(int id)
        {
            ID = id;
        }

        public void Damage(IDamage dmg)
        {
            if (Armor.Value > 0)
            {
                Armor.Value -= (dmg.Damage * dmg.ArmorPenetration);
            }
            else
            {
                Health.Value -= dmg.Damage;

                Health.Value += Armor.Value;
                //Debug.Log(gameObject.name + " damaged " + dmg.Damage + " current health: " + Health);
                CheckHealth();
            }
        }

        public void Damage(float dmg)
        {
            if (Armor.Value > 0)
            {
                Armor.Value -= (dmg* dmg);
            }
            else
            {
                Health.Value -= dmg;

                Health.Value += Armor.Value;
                //Debug.Log(gameObject.name + " damaged " + dmg.Damage + " current health: " + Health);
                CheckHealth();
            }
        }

        private void CheckHealth()
        {
            if (_isDead)
            {
                return;
            }
            if (Health.Value <= 0)
            {
                _isDead = true;
                //OnDeath.Execute();
            }
        }

        public void SetStat(PlayerStat stat)
        {
            throw new System.NotImplementedException();
        }
    }
}