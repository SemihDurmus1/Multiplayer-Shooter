using System.Collections.Generic;
using TopDownShooter.Inventory;
using UnityEngine;

namespace TopDownShooter.Stat
{
    [CreateAssetMenu(menuName = "TopDownShooter/Inventory/Scriptable Stat Manager")]
    public class ScriptableStatManager : AbstractScriptableManager<ScriptableStatManager>
    {
        private List<PlayerStat> PlayerStatList = new();

        public void RegisterStat(PlayerStat stat)
        {
            PlayerStatList.Add(stat);
        }

        public PlayerStat Find(int id)
        {
            for (int i = 0; i < PlayerStatList.Count; i++)
            {
                if (PlayerStatList[i].ID == id)
                {
                    return PlayerStatList[i];
                }
            }

            throw new System.Exception("Couldn't find player stat with id: " + id);
        }

    }
}