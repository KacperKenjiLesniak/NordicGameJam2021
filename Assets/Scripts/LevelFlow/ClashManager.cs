using System;
using System.Linq;
using Recorder;
using UnityEngine;

namespace LevelFlow
{
    public class ClashManager : MonoBehaviour
    {
        public int[] playerPoints = {0, 0};
        public int maxPoints;
        public Countdown countdown;
        
        private void Awake()
        {
            countdown = FindObjectOfType<Countdown>();
        }
        
        public void AddPoint(int amount, int player)
        {
            playerPoints[player] += amount;
        }

        private void Update()
        {
            if (playerPoints[0] > maxPoints && playerPoints[0] > playerPoints[1])
            {
                countdown.enabled = false;
            } 
            
            if (playerPoints[1] > maxPoints && playerPoints[1] > playerPoints[0])
            {
                countdown.enabled = false;
            } 
        }
    }
}