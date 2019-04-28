using UnityEngine;
using UnityEngine.UI;

namespace Script.Menu
{
    public class TranslateMenu : MonoBehaviour
    {
        [SerializeField] private GameObject translateMenu;
        [SerializeField] private Button btn;
        
        public void OnClick()
        {
            if (!gameObject.activeInHierarchy) return;
            transform.parent.gameObject.SetActive(false);
            translateMenu.SetActive(true);
            btn?.Select();
        }
    }
}