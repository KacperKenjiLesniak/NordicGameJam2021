using System;
using MutableObjects.Int;
using UnityEngine;

namespace DefaultNamespace.Movement
{
    public class PlayerWin : MonoBehaviour
    {
        [SerializeField] private MutableInt playersAlive;
        [SerializeField] private GameObject effect;

        public void WinEffect()
        {
            playersAlive.Value -= 1;
            Instantiate(effect, transform.position, Quaternion.identity);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}