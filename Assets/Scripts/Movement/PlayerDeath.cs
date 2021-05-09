using System;
using DefaultNamespace.Audio;
using MutableObjects.Int;
using UnityEngine;

namespace DefaultNamespace.Movement
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private MutableInt playersAlive;
        [SerializeField] private GameObject bloodSplash;
        private AudioManager audioManager;

        private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Killer"))
            {
                playersAlive.Value -= 1;
                audioManager.PlayClip(5);
                Instantiate(bloodSplash, transform.position, Quaternion.identity);
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<InputRecorder>().musicActive = false;
            }
        }
    }
}