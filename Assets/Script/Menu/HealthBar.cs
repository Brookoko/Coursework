using Script.HitBox;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Menu
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Sprite healthSprite;
        [SerializeField] private float offsetX;
        [SerializeField] private float offsetY;

        private float width;
        private float height;
        private BaseAlive playerHealth;
        private int max;
        
        private void Awake()
        {
            width = healthSprite.bounds.size.x * 200;
            height = healthSprite.bounds.size.y * 200;
            playerHealth = GameObject.FindWithTag("Player").GetComponentInChildren<BaseAlive>();
            playerHealth.OnDamage.AddListener(SetHealth);
            max = playerHealth.Health();
            SetHealth();
        }
        
        private void SetHealth()
        {
            int current = playerHealth.Health();
            for (int i = 0; i < max; i++)
            {
                CreateHealth(i, i < current);
            }
        }

        private void CreateHealth(int count, bool unharmed)
        {
            GameObject health = new GameObject(count + "");
            health.transform.parent = transform;
            RectTransform tran = health.AddComponent<RectTransform>();
            tran.pivot = new Vector2(0, 0);
            tran.anchorMin = new Vector2(0, 1);
            tran.anchorMax = new Vector2(0, 1);
            tran.anchoredPosition = new Vector2(count * width + offsetX, offsetY);
            tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            Image image = health.AddComponent<Image>();
            image.sprite = healthSprite;
            if (!unharmed) image.color = new Color(0.3f, 0.3f, 0.3f);
        }
    }
}