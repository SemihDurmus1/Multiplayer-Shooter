using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    public abstract class AbstractInputData : ScriptableObject
    {
        public float Horizontal, Vertical;

        public abstract void ProcessInput()
        {

        }
    }
}