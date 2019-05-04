using System.Collections;
using System.Collections.Generic;
using Script.SaveLoad;
using TMPro;
using UnityEngine;

namespace Script.Menu
{
    public class OptionKeyboard : MonoBehaviour
    {
        public string axis;
        [SerializeField] private Color highlightedColor;
        
        private TextMeshProUGUI text;
        private TextMeshProUGUI sibling;
        private Color defaultColor;
        private Color defaultValueColor;
        private List<string> avoid = new List<string>();

        private void Awake()
        {
            foreach (Transform sib in transform.parent.parent)
            {
                if (sib.childCount < 2) continue;
                string btn = sib.GetChild(1).GetComponent<OptionKeyboard>()?.axis;
                if (!string.IsNullOrEmpty(btn) && !btn.Equals(axis)) avoid.Add(btn);
            }
            text = GetComponent<TextMeshProUGUI>();
            text.text = Input.GetValue(axis);
            sibling = transform.parent.GetChild(0).GetComponent<TextMeshProUGUI>();
            enabled = false;
        }

        public void OnClick()
        {
            if (enabled) return;
            defaultColor = text.color;
            defaultValueColor = sibling.color;
            text.color = highlightedColor;
            sibling.color = highlightedColor;
            enabled = true;
        }

        private void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey && e.type == EventType.KeyDown)
            {
                string value = e.keyCode.ToString();
                string code = Input.ConvertToCode(value);
                string btn = avoid.Find(x => Input.GetValue(x).Equals(code));
                if (string.IsNullOrEmpty(btn)) StartCoroutine(SetButton(code));
                sibling.color = defaultValueColor;
                text.color = defaultColor;
            }
        }

        private IEnumerator SetButton(string code)
        {
            yield return null;
            Input.SetButton(axis, code);
            text.text = Input.GetValue(axis);
            enabled = false;
        }
    }
}