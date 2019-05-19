using Script.Scene;
using UnityEngine;

namespace Script
{
    public class LockCamera : MonoBehaviour
    {
        [SerializeField] private float lockUpper;
        [SerializeField] private float lockLower;
        [SerializeField] private float unlockUpper;
        [SerializeField] private float unlockLower;
        
        private CinemachineLockAxis restriction;
        
        private void Awake()
        {
            restriction = GameObject.FindWithTag("CM").GetComponent<CinemachineLockAxis>();
        }

        public void Lock()
        {
            restriction.SetRestriction(lockUpper, lockLower);
        }

        public void Unlock()
        {
            restriction.SetRestriction(unlockUpper, unlockLower);
        }
    }
}