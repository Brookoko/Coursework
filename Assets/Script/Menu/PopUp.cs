using UnityEngine;

namespace Script.Menu
{
    [CreateAssetMenu(fileName = "New PopUp", menuName = "PopUp")]
    public class PopUp : ScriptableObject
    {
        public string text;
        [Range(0, 1)]public int displayMode;
        [Range(0, 1)]public int fadeMode;
        public float displaySpeed;
        public float fadeSpeed;
        public float timeOnScreen;
        public int[] index;
        public float[] speed;
    }
}