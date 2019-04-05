using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Player
{
    public class PlayerSMStats : MonoBehaviour
    {
        public Transform groundCheck;
        public Transform ceilingCheck;
        public float radius = .2f;
        public LayerMask whatIsGround;
    }
}
