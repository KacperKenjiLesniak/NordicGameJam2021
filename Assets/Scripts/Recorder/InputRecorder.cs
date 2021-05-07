using System;
using System.Collections;
using System.Collections.Generic;
using MutableObjects.Float;
using Recorder;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    public Queue<TimedInput> inputQueue = new Queue<TimedInput>();
    
    public MutableFloat currentRecordingTime;
    public Countdown countdown;

    private void Awake()
    {
        countdown = FindObjectOfType<Countdown>();
    }

    void Update()
    {
        if (countdown.recordingState == RecordingState.PLAYING)
        {
            HandleReplay();
        }
    }

    private void HandleReplay()
    {
        if (inputQueue.Count > 0 && currentRecordingTime.Value >= inputQueue.Peek().timestamp)
        {
            var timedInput = inputQueue.Dequeue();
            Debug.Log(timedInput.input + " " + timedInput.timestamp);
        }
    }

    public void AddInput(InputType input)
    {
        if (countdown.recordingState == RecordingState.RECORDING)
        {
            inputQueue.Enqueue(new TimedInput(currentRecordingTime.Value, input));
        }
    }
    

}
