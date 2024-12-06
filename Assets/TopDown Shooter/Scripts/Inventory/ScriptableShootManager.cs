using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDownShooter/Inventory/ScriptableShootManager")]
    public class ScriptableShootManager : AbstractScriptableManager<ScriptableShootManager>
    {
        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("scriptable shoot manager activated");
        }

        public override void Destroy()
        {
            base.Destroy();
            Debug.Log("scriptable shoot manager destroyed");
        }

        public void Shoot(Vector3 origin, Vector3 direction)
        {
            RaycastHit hit;
            var physic = Physics.Raycast(origin, direction, out hit);

            if (physic)
            {
                Debug.Log("Shoot find " + hit.collider.name);
            }
        }
    }
}