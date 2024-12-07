using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.AI
{
    public class InputDataAI : AbstractInputData
    {
        protected Vector3 _currentTarget;
        protected Transform _targetTransform;


        public void SetTarget(Transform targetTransfrom, Vector3 target)
        {
            _targetTransform = targetTransfrom;
            _currentTarget = target;
        }

        public override void ProcessInput()
        {

        }
    }
}