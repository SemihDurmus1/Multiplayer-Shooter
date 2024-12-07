using UnityEngine;

namespace TopDownShooter.AI
{
    [CreateAssetMenu(menuName = "TopDownShooter/Input/AI/Rotation Input Data")]
    public class InputRotationDataAI : InputDataAI
    {
        public override void ProcessInput()
        {
            base.ProcessInput();

            Vector3 dir = _currentTarget - _targetTransform.position;

            if (Mathf.Abs(dir.y - _targetTransform.rotation.eulerAngles.y) > 0.25f)//0.25f
            {
                Horizontal = 1;
            }
            else
            {
                Horizontal = 0;
            }
        }
    }
}