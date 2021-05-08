using System;
using DefaultNamespace;
using DefaultNamespace.Movement;
using MutableObjects.Int;
using UnityEngine;

namespace LevelFlow
{
    public class WinArea : MonoBehaviour
    {
        public MutableInt playerScore;
        public string playerTag;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(playerTag))
            {
                playerScore.Value += 1;
                other.GetComponent<PlayerWin>().WinEffect();
                enabled = false;
            }
        }
    }
}