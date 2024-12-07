using UnityEngine;

namespace TopDownShooter.AI
{
    [CreateAssetMenu(menuName = "TopDownShooter/Input/AI/Movement Input Data")]
    public class InputMovementDataAI : InputDataAI
    {
        public override void ProcessInput()
        {
            //base.ProcessInput();

            float distance = Vector3.Distance( _targetTransform.position, _currentTarget);
            if (distance > 0)
            {
                Horizontal = 1;
            }
            else
            {
                Horizontal   = 0;
            }

            Vector3 dir = _currentTarget - _targetTransform.position;
            var rotation = Quaternion.LookRotation(dir, Vector3.up).eulerAngles;

            //var rotationGap

            if (Mathf.Abs(rotation.y - _targetTransform.rotation.eulerAngles.y) > 0.25f)//0.25f
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