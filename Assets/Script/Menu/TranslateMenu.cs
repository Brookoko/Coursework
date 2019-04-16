using UnityEngine;

namespace Script.Menu
{
    public class TranslateMenu : MonoBehaviour
    {
        [SerializeField] private GameObject translateMenu;

        public void OnClick()
        {
            if (!gameObject.activeInHierarchy) return;
            transform.parent.gameObject.SetActive(false);
            translateMenu.SetActive(true);
        }
    }
}