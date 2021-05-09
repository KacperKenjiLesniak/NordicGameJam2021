using System;
using MutableObjects.Int;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class WinSceneUI : MonoBehaviour
    {
        public MutableInt[] playerScores;

        private void Start()
        {
            GetComponent<TMP_Text>().text = "Player " +                             
                (playerScores[0].Value > playerScores[1].Value ? "1" : "2") + " Won!!!";

        }

        public void LoadMainMenu()
        {
            SceneManager.LoadSceneAsync("Main Menu");
        }
    }
}