using UnityEngine;

namespace Script.Menu
{
    [CreateAssetMenu(fileName = "New PopUpImage", menuName = "PopUpImage")]
    public class PopUpImage : ScriptableObject
    {
        public Sprite image;
        public bool skippable;
        public string skipButton;
        public float timeOnScreen;
        [Range(0, 1)]public int displayMode;
        [Range(0, 1)]public int fadeMode;
        public float displaySpeed;
        public float fadeSpeed;
    }
}