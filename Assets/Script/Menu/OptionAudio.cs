using Script.SaveLoad;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Menu
{
    public class OptionAudio : MonoBehaviour
    {
        [SerializeField] private string parameter;
        [SerializeField] private float timeBtwChange = 0.1f;
        
        private Slider slider;
        private GameObject btn;
        private float timer;
        
        private void Awake()
        {
            timer = timeBtwChange;
            slider = GetComponent<Slider>();
            btn = transform.parent.gameObject;
            slider.value = AudioManager.GetVolume(parameter);
        }

        public void SetVolume(float volume)
        {
            int v = (int) volume;
            AudioManager.SetVolume(parameter, v);
            slider.value = v;
        }

        private void Update()
        {
            GameObject current = EventSystem.current.currentSelectedGameObject;
            if (current && current.Equals(btn))
            {
                timer -= Time.unscaledDeltaTime;
                if (timer <= 0)
                {
                    float value = UnityEngine.Input.GetAxisRaw("Horizontal");
                    if (Mathf.Abs(value) > 0) slider.value += value;
                    timer = timeBtwChange;
                }
            }
        }
    }
}