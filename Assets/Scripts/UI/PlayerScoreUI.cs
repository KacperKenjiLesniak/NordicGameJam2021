using System;
using MutableObjects.Int;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerScoreUI : MonoBehaviour
    {
        public MutableInt playerScore;

        private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            text.text = "" + playerScore.Value;
        }
    }
}