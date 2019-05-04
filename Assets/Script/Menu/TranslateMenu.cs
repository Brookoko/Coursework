using Script.Effects;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Menu
{
    public class TranslateMenu : MonoBehaviour
    {
        [SerializeField] private GameObject translateMenu;
        [SerializeField] private FadingEffect fadding;
        
        public void OnClick()
        {
            if (!gameObject.activeInHierarchy) return;
            transform.parent.gameObject.SetActive(false);
            translateMenu.SetActive(true);
        }

        public void ChangeEvent()
        {
            fadding.OnFadeOutEnd.RemoveAllListeners();
            fadding.OnFadeOutEnd.AddListener(OnClick);
        }
    }
}