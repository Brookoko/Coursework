using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace Script.SaveLoad
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioMixer Mixer;
        [SerializeField] private AudioMixer mixer;

        private void Awake()
        {
            if (!Mixer) Mixer = mixer;
        }

        public static void SetVolume(string parameter, int value)
        {
            float volume = (float) value / 10;
            volume = volume > 0 ? volume : 0.0001f;
            Mixer.SetFloat(parameter, Mathf.Log10(volume) * 20);
        }
        
        public static int GetVolume(string parameter)
        {
            return Mathf.RoundToInt(Mixer.GetFloat(parameter, out var v) ? 10 * Mathf.Pow(10, v / 20) : 10);
        }
    }
}