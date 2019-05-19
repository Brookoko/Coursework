using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Menu
{
    public class Menu : MonoBehaviour
    {
        private GameObject wasSelected;
        
        private void Start()
        {
            SelectFirstButton();
        }

        private void OnEnable()
        {
            SelectFirstButton();
        }
        
        private void OnDisable()
        {
            SelectFirstButton();
        }

        public void SelectFirstButton()
        {
            foreach (Transform child in transform)
            {
                Button btn = child.GetComponent<Button>();
                if (btn && btn.gameObject.activeInHierarchy)
                {
                    if (gameObject.activeInHierarchy) StartCoroutine(Select(btn));
                    else btn.Select();
                    break;
                }
            }
        }

        private IEnumerator Select(Button btn)
        {
            EventSystem.current.SetSelectedGameObject(null);
            yield return null;
            btn.Select();
        }

        private void OnGUI()
        {
            GameObject current = EventSystem.current.currentSelectedGameObject;
            if (!current && wasSelected) StartCoroutine(Select(wasSelected.GetComponent<Button>()));
            wasSelected = current;
        }
    }
}