using UnityEngine;


namespace TopDownShooter.Utility
{
    public class DontDestroyOnLoadController : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}