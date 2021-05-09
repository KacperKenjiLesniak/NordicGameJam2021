using MutableObjects.Float;
using Recorder;
using TMPro;
using UnityEngine;

namespace UI
{
    public class RecordingCountdownUI : MonoBehaviour
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
                        countdownText.text = "RECORD YOUR INPUT! ";
                        countdownText.text +=  Mathf.CeilToInt(10 - currentRecordingTime.Value).ToString();
                        break;
                    case RecordingState.BREAK:
                        countdownText.text = "";
                        break;
                    case RecordingState.PLAYING:
                        countdownText.text = "";
                        break;
                }

            }
        }
    }
}