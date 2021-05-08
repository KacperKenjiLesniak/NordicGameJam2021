using System;
using MutableObjects.Int;
using UnityEngine;

namespace DefaultNamespace.Movement
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private MutableInt playersAlive;
        [SerializeField] private GameObject bloodSplash;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Killer"))
            {
                playersAlive.Value -= 1;
                Instantiate(bloodSplash, transform.position, Quaternion.identity);
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}