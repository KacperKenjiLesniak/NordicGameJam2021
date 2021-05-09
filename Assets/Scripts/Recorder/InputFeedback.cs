using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;
using UnityEngine.UI;
using TMPro;

public class InputFeedback : MonoBehaviour
{
    [SerializeField] private SpriteRenderer up, left, right, mine;
    [SerializeField] Color normal, pressed, disabled;
    public int minesLeft;
    private bool isRecording, movingLeft;

    public Countdown countdown;
    private bool animate;
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

            animate = true;
        }

        if (countdown.recordingState == RecordingState.RECORDING)
        {
            animate = false;
        }
    }

    public void ShowFeedback(string actionName)
    {
        if (!animate)
        {
            if (actionName == "Left")
            {
                left.color = pressed;
                movingLeft = true;
            }

            if (actionName == "Right")
            {
                right.color = pressed;
                movingLeft = false;
            }

            if (actionName == "Jump")
            {
                up.color = pressed;
                StartCoroutine(FadeToGreen(up));
            }

            if (actionName == "Dropped mine")
            {
                mine.color = pressed;
                if (minesLeft == 0)
                {
                    StartCoroutine(FadeToGrey(mine));
                }
                else
                {
                    StartCoroutine(FadeToGreen(mine));
                }
            }

            if (actionName.Contains("Stop"))
            {
                Debug.Log("Color back to normal");
                left.color = normal;
                right.color = normal;
            }
        }
    }

    IEnumerator FadeToGrey(SpriteRenderer rd)
    {
        yield return new WaitForSeconds(.3f);
        rd.color = disabled;
    }

    IEnumerator FadeToGreen(SpriteRenderer rd)
    {
        yield return new WaitForSeconds(.3f);
        rd.color = normal;
    }
}