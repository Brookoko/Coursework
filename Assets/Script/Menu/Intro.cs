using UnityEngine;

namespace Script.Menu
{
    public class Intro : MonoBehaviour
    {
        [SerializeField] private GameObject translateMenu;
        
        private static bool wasLoaded;

        private void Start()
        {
            if (!wasLoaded) wasLoaded = true;
            else
            {
                gameObject.SetActive(false);
                translateMenu.SetActive(true);
            }
        }
    }
}