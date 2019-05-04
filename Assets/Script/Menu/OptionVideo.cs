using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Script.Menu
{
    public class OptionVideo : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown resolutionDropdown;
        
        private Resolution[] resolutions;

        private void Awake()
        {
            resolutions = Screen.resolutions;
            List<string> options = resolutions.Select(res => res.width + " x " + res.height).ToList();
            resolutionDropdown.ClearOptions();
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = Array.IndexOf(resolutions, Screen.currentResolution);
            resolutionDropdown.RefreshShownValue();
        }
        
        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        public void SetResolution(int index)
        {
            Resolution res = resolutions[index];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        }

        public void SetQuality(int index)
        {
            QualitySettings.SetQualityLevel(index);
        }
    }
}