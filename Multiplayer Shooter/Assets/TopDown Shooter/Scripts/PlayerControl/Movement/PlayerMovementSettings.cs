using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    [CreateAssetMenu(menuName = "TopDownShooter/Player/Movement Settings")]
    public class PlayerMovementSettings : ScriptableObject
    {
        public float HorizontalSpeed = 5;
        public float VerticalSpeed = 5;
    }
}