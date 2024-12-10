using TopDownShooter.Stat;
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
            //Debug.Log("scriptable shoot manager activated");
        }

        public override void Destroy()
        {
            base.Destroy();
            //Debug.Log("scriptable shoot manager destroyed");
        }

        public void Shoot(Vector3 origin, Vector3 direction, IDamage damage)
        {
            RaycastHit rHit;
            var physic = Physics.Raycast(origin, direction, out rHit);

            if (physic)
            {
                Debug.Log("Shoot find " + rHit.collider.name);

                int colliderInstanceID = rHit.collider.GetInstanceID();

                if (DamageableHelper.DamageableList.ContainsKey(colliderInstanceID))
                {
                    DamageableHelper.DamageableList[colliderInstanceID].Damage(damage);//Magic Number
                }
            }
        }
    }
}