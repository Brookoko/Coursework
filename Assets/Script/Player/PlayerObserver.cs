using Script.Player.States;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Player
{
    public class PlayerObserver : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnLandEvent;

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
            wasOnGround = onGround;
        }
    }
}