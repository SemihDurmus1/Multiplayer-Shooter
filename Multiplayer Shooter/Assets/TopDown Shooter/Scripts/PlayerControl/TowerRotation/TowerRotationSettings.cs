using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    [CreateAssetMenu(menuName = "TopDownShooter/Player/Tower Rotation Settings")]
    public class TowerRotationSettings : ScriptableObject
    {
        public float TowerRotationSpeed = 1f;
    }
}