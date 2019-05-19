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
        
        private void Start()
        {
            width = healthSprite.bounds.size.x * 66;
            height = healthSprite.bounds.size.y * 66;
            playerHealth = GameObject.FindWithTag("Player").GetComponentInChildren<BaseAlive>();
            playerHealth.OnDamage.AddListener(SetHealth);
            playerHealth.OnHeal.AddListener(SetHealth);
            max = playerHealth.Health();
            SetHealth();
        }
        
        private void SetHealth()
        {
            DeleteHealth();
            int current = playerHealth.Health();
            for (int i = 0; i < max; i++)
            {
                CreateHealth(i, i < current);
            }
        }

        private void DeleteHealth()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
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