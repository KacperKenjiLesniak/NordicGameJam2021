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
            
            if (player1RoundsWon.Value == 3)
            {
                //player 1 won
            }
            else if (player2RoundsWon.Value == 3)
            {
                //player 2 won
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