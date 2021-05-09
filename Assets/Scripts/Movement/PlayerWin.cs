using System;
using DefaultNamespace.Audio;
using MutableObjects.Int;
using UnityEngine;

namespace DefaultNamespace.Movement
{
    public class PlayerWin : MonoBehaviour
    {
        [SerializeField] private MutableInt playersAlive;
        [SerializeField] private GameObject effect;
        
        private AudioManager audioManager;

        private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
        public void WinEffect()
        {
            playersAlive.Value -= 1;
            Instantiate(effect, transform.position, Quaternion.identity);
            audioManager.PlayClip(6);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}