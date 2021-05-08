using System;
using System.Linq;
using MutableObjects.Int;
using Recorder;
using UnityEngine;

namespace LevelFlow
{
    public class ClashManager : MonoBehaviour
    {
        public int[] playerPoints = {0, 0};
        public int maxPoints;
        public MutableInt currentLevel;
        public GameObject[] levels;
        
        private Countdown countdown;

        private void Awake()
        {
            countdown = FindObjectOfType<Countdown>();
        }

        private void Start()
        {
            Array.ForEach(levels, level => level.SetActive(false));
            levels[currentLevel.Value].SetActive(true);
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