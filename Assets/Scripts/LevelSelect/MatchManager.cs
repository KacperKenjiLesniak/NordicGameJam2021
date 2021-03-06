using System;
using MutableObjects.Int;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.LevelSelect
{
    public class MatchManager : MonoBehaviour
    {
        public int[] levelList = {0, 1, 2};
        public int currentLevelIndex;
        public int currentRound;
        public MutableInt currentLevel;

        public MutableInt player1RoundsWon;
        public MutableInt player2RoundsWon;

        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        public void ChooseLevel(int level)
        {
            levelList[currentLevelIndex] = level;
            currentLevelIndex = (currentLevelIndex + 1) % 3;
        }

        public void NextLevel()
        {
            Debug.Log("Rounds won : " + player1RoundsWon.Value + " " + player2RoundsWon.Value);

            if (currentRound == 2)
            {
                SceneManager.LoadSceneAsync("WinScene");
            }
            if (player1RoundsWon.Value >= 2 || player2RoundsWon.Value >= 2)
            {
                SceneManager.LoadSceneAsync("WinScene");
            }
            else
            {
                currentRound += 1;
                currentLevel.Value = levelList[currentRound];
                Debug.Log("Set current level to: " + levelList[currentRound]);
                SceneManager.LoadSceneAsync("GameScene");
            }
        }

        public void StartGame()
        {
            if (levelList.Length == 3)
            {
                Array.Sort(levelList);
                currentLevel.Value = levelList[currentRound];
                Debug.Log("Set current level to: " + levelList[currentRound]);
                SceneManager.LoadSceneAsync("GameScene");
            }
        }
    }
}