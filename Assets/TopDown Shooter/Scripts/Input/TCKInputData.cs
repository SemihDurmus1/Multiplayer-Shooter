using TopDownShooter.PlayerInput;
using TouchControlsKit;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "TopDownShooter/Input/TCK Input Data")]
    public class TCKInputData : AbstractInputData
    {
        public string AxisName;

        public bool isAction;

        public override void ProcessInput()
        {
            if (isAction)
            {
                if (TCKInput.GetAction(AxisName, EActionEvent.Down))
                {
                    Horizontal = 1;
                }
                else
                {
                    Horizontal = 0;
                }
            }
            else
            {
                Vector2 move = TCKInput.GetAxis(AxisName);

                Horizontal = move.x;
                Vertical = move.y;
            }
        }
    }
}