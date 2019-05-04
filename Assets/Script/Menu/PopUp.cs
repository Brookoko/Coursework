using UnityEngine;
using TMPro;

namespace Script.Menu
{
    [CreateAssetMenu(fileName = "New PopUp", menuName = "PopUp")]
    public class PopUp : ScriptableObject
    {
        [TextArea(3, 10)]
        public string text;
        public TMP_FontAsset font;
        public bool skippable;
        public string skipButton;
        public float timeOnScreen;
        [Range(0, 1)]public int displayMode;
        [Range(0, 1)]public int fadeMode;
        public float displaySpeed;
        public float fadeSpeed;
        public int[] index;
        public float[] speed;
    }
}