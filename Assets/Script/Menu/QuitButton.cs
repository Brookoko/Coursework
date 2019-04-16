using UnityEngine;

namespace Script.Menu
{
    public class QuitButton : MonoBehaviour
    {
        public void OnClick()
        {
            Application.Quit();
        }
    }
}