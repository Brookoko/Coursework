using UnityEngine;

namespace Script.SaveLoad
{
    public class SaveLoadSetting : MonoBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Input.SetButton("Jump", Input.ConvertToCode(PlayerPrefs.GetInt("Jump", -1)));
            Input.SetButton("Dash", Input.ConvertToCode(PlayerPrefs.GetInt("Dash", -1)));
            Input.SetButton("Crouch", Input.ConvertToCode(PlayerPrefs.GetInt("Crouch", -1)));
            AudioManager.SetVolume("Volume", PlayerPrefs.GetInt("Volume", 10));
            AudioManager.SetVolume("Music", PlayerPrefs.GetInt("Music", 10));
            AudioManager.SetVolume("Effect", PlayerPrefs.GetInt("Effect", 10));
            Screen.fullScreen = PlayerPrefs.GetInt("FullScreen", 1) == 1;
            int width = PlayerPrefs.GetInt("Width", Screen.width);
            int height = PlayerPrefs.GetInt("Height", Screen.height);
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality", 2));
        }

        private void OnDestroy()
        {
            OnApplicationQuit();
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt("Jump", Input.ConvertToInt(Input.GetValue("Jump")));
            PlayerPrefs.SetInt("Dash", Input.ConvertToInt(Input.GetValue("Dash")));
            PlayerPrefs.SetInt("Crouch", Input.ConvertToInt(Input.GetValue("Crouch")));
            PlayerPrefs.SetInt("Volume", AudioManager.GetVolume("Volume"));
            PlayerPrefs.SetInt("Music", AudioManager.GetVolume("Music"));
            PlayerPrefs.SetInt("Effect", AudioManager.GetVolume("Effect"));
            PlayerPrefs.SetInt("FullScreen", Screen.fullScreen ? 1 : 0);
            PlayerPrefs.SetInt("Width", Screen.width);
            PlayerPrefs.SetInt("Height", Screen.height);
            PlayerPrefs.SetInt("Quality", QualitySettings.GetQualityLevel());
            PlayerPrefs.Save();
        }
    }
}