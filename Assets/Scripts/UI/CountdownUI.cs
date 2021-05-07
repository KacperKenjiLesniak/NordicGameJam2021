using System;
using MutableObjects.Float;
using Recorder;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CountdownUI : MonoBehaviour
    {
        public MutableFloat currentRecordingTime;
        public TMP_Text countdownText;
        public Countdown countdown;

        private void Awake()
        {
            countdown = FindObjectOfType<Countdown>();
            countdownText = GetComponent<TMP_Text>();

        }

        private void Update()
        {
            if (countdownText != null)
            {
                switch(countdown.recordingState)
                {
                    case RecordingState.RECORDING:
                        countdownText.text = "Recording ";
                        break;
                    case RecordingState.BREAK:
                        countdownText.text = "Break ";
                        break;
                    case RecordingState.PLAYING:
                        countdownText.text = "Playing ";
                        break;
                }

                countdownText.text += currentRecordingTime.Value.ToString("F2");
            }
        }
    }
}