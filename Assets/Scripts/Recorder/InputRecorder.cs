using System.Collections;
using System.Collections.Generic;
using Recorder;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{

    
    public bool recording = true;
    public float recordingLength = 5f;
    public Queue<TimedInput> timedInput = new Queue<TimedInput>();
    public float currentRecordingTime = 0f;
    
    void Start()
    {
        InvokeRepeating(nameof(SwitchRecording), 0f, recordingLength);
    }

    void Update()
    {
        currentRecordingTime += Time.deltaTime;
        
    }

    public void AddInput(TimedInput input)
    {
        timedInput.Enqueue(input);
    }
    
    public void SwitchRecording()
    {
        recording = !recording;
        currentRecordingTime = 0f;
    }
}
