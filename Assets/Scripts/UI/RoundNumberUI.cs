using System;
using MutableObjects.Int;
using TMPro;
using UnityEngine;

namespace UI
{
    public class RoundNumberUI : MonoBehaviour
    {
        public MutableInt roundNumber;

        private void Start()
        {
            GetComponent<TMP_Text>().text = (roundNumber.Value + 1).ToString();
        }
    }
}