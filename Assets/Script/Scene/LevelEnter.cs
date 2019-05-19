using UnityEngine;
using UnityEngine.Events;

namespace Script.Scene
{
    public class LevelEnter : MonoBehaviour
    {
        public UnityEvent OnFirstLoad;
        [SerializeField] private UnityEvent OnEnter;
        [Space]
        public float upper;
        public float lower;

        private int numberOfLoading;
        
        public void SetUpScene()
        {
            SetCinemachineBoundry();
            OnEnter.Invoke();
        }

        private void SetCinemachineBoundry()
        {
            GameObject obj = GameObject.FindWithTag("CM");
            if (obj) obj.GetComponent<CinemachineLockAxis>().SetRestriction(upper, lower);
        }
    }
}