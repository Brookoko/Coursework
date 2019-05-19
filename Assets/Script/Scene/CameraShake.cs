using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Script.Scene
{
    public class CameraShake : MonoBehaviour
    {
        private CinemachineVirtualCamera cam;
        private CinemachineBasicMultiChannelPerlin noise;

        private void Awake()
        {
            cam = GetComponent<CinemachineVirtualCamera>();
            noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        
        public IEnumerator Shake(float duration, float magnitude, float frequency)
        {
            noise.m_AmplitudeGain = magnitude;
            noise.m_FrequencyGain = frequency;
            yield return new WaitForSeconds(duration);
            noise.m_AmplitudeGain = 0;
            noise.m_FrequencyGain = 0;
        }
    }
}