using System;
using System.Collections.Generic;
using MutableObjects.Float;
using UnityEngine;

namespace Recorder
{
    
    public class Countdown : MonoBehaviour
    {
        public RecordingState recordingState = RecordingState.BREAK;
        public RecordingState recordingStateAfterBreak = RecordingState.RECORDING;
        public float recordingLength = 5f;
        public float breakLength = 3f;
    
        public MutableFloat currentRecordingTime;

        void Update()
        {
            currentRecordingTime.Value += Time.deltaTime;
            switch (recordingState)
            {
                case RecordingState.RECORDING:
                    if (currentRecordingTime.Value >= recordingLength)
                    {
                        recordingState = RecordingState.BREAK;
                        recordingStateAfterBreak = RecordingState.PLAYING;
                        currentRecordingTime.Value = 0f;
                    }
                    break;
                case RecordingState.BREAK:
                    if (currentRecordingTime.Value >= breakLength)
                    {
                        recordingState = recordingStateAfterBreak;
                        currentRecordingTime.Value = 0f;
                    }
                    break;
                case RecordingState.PLAYING:
                    if (currentRecordingTime.Value >= recordingLength)
                    {
                        recordingState = RecordingState.BREAK;
                        recordingStateAfterBreak = RecordingState.RECORDING;
                        currentRecordingTime.Value = 0f;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}