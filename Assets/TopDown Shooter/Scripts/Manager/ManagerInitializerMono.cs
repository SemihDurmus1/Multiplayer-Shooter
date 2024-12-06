using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class ManagerInitializerMono : MonoBehaviour
    {
        [SerializeField]private AbstractScriptableManagerBase[] _abstractScriptableManagerBaseArray;
        private List<AbstractScriptableManagerBase> _instantiatedAbstractScriptableManagerList;

        private void Start()
        {
            _instantiatedAbstractScriptableManagerList = new List<AbstractScriptableManagerBase>(_abstractScriptableManagerBaseArray.Length);

            for (int i = 0; i < _abstractScriptableManagerBaseArray.Length; i++)
            {
                var instantiated = Instantiate(_abstractScriptableManagerBaseArray[i]);
                instantiated.Initialize();
                _instantiatedAbstractScriptableManagerList.Add(instantiated);
            }
        }

        private void OnDestroy()
        {
            if (_instantiatedAbstractScriptableManagerList != null)
            {
                for (int i = 0; i < _instantiatedAbstractScriptableManagerList.Count; i++)
                {
                    _instantiatedAbstractScriptableManagerList[i].Destroy();
                }
            }

        }
    }
}