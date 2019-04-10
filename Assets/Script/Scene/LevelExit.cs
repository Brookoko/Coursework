using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Scene
{
    public class LevelExit : MonoBehaviour
    {
        [SerializeField] private int SceneIndexToLoad;
        [SerializeField] private SceneTransition manager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                manager.Transite(SceneIndexToLoad);
            }
        }
    }   
}
