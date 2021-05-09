using System;
using System.Linq;
using DefaultNamespace.Audio;
using DefaultNamespace.LevelSelect;
using MutableObjects.Int;
using Recorder;
using UnityEngine;

namespace LevelFlow
{
    public class ClashManager : MonoBehaviour
    {
        public MutableInt[] playerScores;
        public int maxPoints;
        public MutableInt currentLevel;
        public GameObject[] levels;
        
        private Countdown countdown;
        private MatchManager matchManager;
        private AudioManager audioManager;
        public MutableInt player1RoundsWon;
        public MutableInt player2RoundsWon;

        private void Awake()
        {
            countdown = FindObjectOfType<Countdown>();
            matchManager = FindObjectOfType<MatchManager>();
        }

        private void Start()
        {
            Debug.Log("Instantiating environment number: " + currentLevel.Value);

            Array.ForEach(levels, level => level.SetActive(false));
            levels[currentLevel.Value].SetActive(true);
        }

        private void Update()
        {
            if (countdown.recordingState == RecordingState.BREAK)
            {
                if (playerScores[0].Value >= maxPoints && playerScores[0].Value > playerScores[1].Value)
                {
                    player1RoundsWon.Value += 1;
                    playerScores[0].Value = 0;
                    playerScores[1].Value = 0;
                    matchManager.NextLevel();
                }

                if (playerScores[1].Value >= maxPoints && playerScores[1].Value > playerScores[0].Value)
                {
                    player2RoundsWon.Value += 1;
                    playerScores[0].Value = 0;
                    playerScores[1].Value = 0;
                    matchManager.NextLevel();
                }
            }
        }
    }
}