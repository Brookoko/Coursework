using Script.Scene;
using UnityEngine;

namespace Script.Cutscene
{
    public class CameraShakeCutscene : MonoBehaviour
    {
        [SerializeField] private CameraShake shake;
        
        private void OnEnable()
        {
            StartCoroutine(shake.Shake(0.3f, 20f, 3f));
        }
    }
}