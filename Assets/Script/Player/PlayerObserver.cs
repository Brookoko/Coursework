using UnityEngine;
using UnityEngine.Events;

namespace Script.Player
{
    public class PlayerObserver : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnLandEvent;
        [SerializeField] private UnityEvent OnFallEvent;
        [SerializeField] private UnityEvent OnNearGround;
        
        private bool wasOnGround = true;
        private Player player;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }

        private void FixedUpdate()
        {
            var onGround = player.IsOnGround();
            if (!wasOnGround && onGround) OnLandEvent.Invoke();
            if (wasOnGround && !onGround) OnFallEvent.Invoke();
            if (Input.GetButtonDown("Jump") && player.IsNearGround()) OnNearGround.Invoke();
            wasOnGround = onGround;
        }
    }
}