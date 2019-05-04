using UnityEngine;
using UnityEngine.Events;

namespace Script.Scene
{
    public class LevelEnter : MonoBehaviour
    {
        public UnityEvent OnFirstLoad;
        [SerializeField] private UnityEvent OnEnter;
        [Space]
        [SerializeField] private CinemachineLockAxis boundry;
        [SerializeField] private float upper;
        [SerializeField] private float lower;

        private int numberOfLoading;
        
        public void SetUpScene()
        {
            SetCinemachineBoundries();
            OnEnter.Invoke();
        }

        private void SetCinemachineBoundries()
        {
            boundry.upper = upper;
            boundry.lower = lower;
        }
    }
}