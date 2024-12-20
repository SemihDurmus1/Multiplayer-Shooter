using UnityEngine;

namespace TopDownShooter.Stat
{
    public interface IPlayerStatHolder
    {
        PlayerStat playerStat { get; }

        void SetStat(PlayerStat stat);
    }
}