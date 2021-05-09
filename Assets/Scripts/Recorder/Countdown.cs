using System;
using System.Collections.Generic;
using GameEvents.Game;
using MutableObjects.Float;
using MutableObjects.Int;
using UnityEngine;

namespace Recorder
{
    
    public class Countdown : MonoBehaviour
    {
        public GameEvent resetLevel;
        
        public RecordingState recordingState = RecordingState.BREAK;
        public RecordingState recordingStateAfterBreak = RecordingState.RECORDING;
        public float recordingLength = 5f;
        public float breakLength = 3f;
        public MutableFloat currentRecordingTime;
        public MutableInt playersAlive;

        private InputRecorder[] inputRecorders;
        
        private void Start()
        {
            playersAlive.Value = FindObjectsOfType<PlayerMovement>().Length;
            inputRecorders = FindObjectsOfType<InputRecorder>();
        }

        void Update()
        {
            currentRecordingTime.Value += Time.deltaTime;
            switch (recordingState)
            {
                case RecordingState.RECORDING:
                    HandleRecordingState();
                    break;
                case RecordingState.BREAK:
                    HandleBreakState();
                    break;
                case RecordingState.PLAYING:
                    HandlePlayingState();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void HandleRecordingState()
        {
            if (currentRecordingTime.Value >= recordingLength)
            {
                recordingState = RecordingState.BREAK;
                recordingStateAfterBreak = RecordingState.PLAYING;
                currentRecordingTime.Value = 0f;
            }
        }

        private void HandleBreakState()
        {
            if (currentRecordingTime.Value >= breakLength)
            {
                recordingState = recordingStateAfterBreak;
                currentRecordingTime.Value = 0f;
            }
        }

        private void HandlePlayingState()
        {
            if (playersAlive.Value == 0)
            {
                currentRecordingTime.Value = recordingLength;
                foreach (var inputRecorder in inputRecorders)
                {
                    inputRecorder.ClearInputQueue();
                }
            }

            if (currentRecordingTime.Value >= recordingLength)
            {
                recordingState = RecordingState.BREAK;
                recordingStateAfterBreak = RecordingState.RECORDING;
                currentRecordingTime.Value = 0f;
                playersAlive.Value = FindObjectsOfType<PlayerMovement>().Length;
                resetLevel.RaiseGameEvent();
            }
        }
    }
}