using Script.AI;
using UnityEngine;

namespace Script
{
    public class DeadZoneReaction : MonoBehaviour, IEntityReaction
    {
        [SerializeField] private float deadZone;
        [SerializeField] private float timeInDeadZoneToReact;
        [SerializeField] private float speedReaction;
        
        private float deadZoneTimer;
        private bool wasInDeadZone;
        private Rigidbody2D rb;
        private Transform tran;
        
        private void Awake()
        {
            if (transform.CompareTag("Enemy"))
            {
                tran = transform;
                rb = GetComponent<Rigidbody2D>();
            }
            else
            {
                tran = transform.parent;
                rb = tran.GetComponent<Rigidbody2D>();
            }
        }

        private void Update()
        {
            deadZoneTimer -= Time.deltaTime;
        }

        public bool IsEntityVisible(Transform entity)
        {
            bool visible = Mathf.Abs(tran.position.x - entity.position.x) > deadZone;

            if (!visible)
            {
                if (!wasInDeadZone)
                {
                    wasInDeadZone = true;
                    deadZoneTimer = timeInDeadZoneToReact;
                }
                else if (deadZoneTimer < 0) Reaction(entity);
            }
            else
            {
                wasInDeadZone = false;
                deadZoneTimer = timeInDeadZoneToReact;
            }
            
            return visible;
        }

        public void Reaction(Transform entity)
        {
            if (deadZoneTimer > 0) return;
            
            var x = tran.position.x - entity.position.x > 0 ? 1 : -1;
            var target = tran.position + Vector3.right * x * deadZone * 100;
        
            rb.MovePosition(Vector2.MoveTowards(tran.position, target, Time.deltaTime * speedReaction));
        }
    }
}