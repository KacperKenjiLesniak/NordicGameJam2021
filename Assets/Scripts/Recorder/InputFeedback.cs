using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;
using UnityEngine.UI;
using TMPro;

public class InputFeedback : MonoBehaviour
{
    [SerializeField] private SpriteRenderer up,left,right,mine;
    [SerializeField] Color normal, pressed;
    private bool isRecording;
    public Countdown countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = FindObjectOfType<Countdown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.recordingState == RecordingState.PLAYING || countdown.recordingState == RecordingState.RECORDING)
        {


        }

        if (countdown.recordingState == RecordingState.RECORDING)
        {

        }
    }

    public void ShowFeedback(string actionName)
    {
        if (actionName == "Left")
        {
        }

    }

}
