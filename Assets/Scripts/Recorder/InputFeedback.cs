using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;
using UnityEngine.UI;
using TMPro;

public class InputFeedback : MonoBehaviour
{
    [SerializeField] private SpriteRenderer up,left,right,mine;
    [SerializeField] Color normal, pressed, disabled;
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
        if (animate)
        {
            if (actionName == "Left")
            {
                StartCoroutine(FadeToRed(left));
            }
            if (actionName == "Right")
            {
                StartCoroutine(FadeToRed(right));
            }
            if (actionName == "Jump")
            {
                StartCoroutine(FadeToRed(up));
                StartCoroutine(FadeToGreen(up));
            }
            if (actionName == "Dropped mine")
            {
                StartCoroutine(FadeToRed(mine));
                if (this.gameObject.GetComponent<PlayerMovement>().mines == 0)
                {
                    StartCoroutine(FadeToGrey(mine));
                }
                else
                {
                    StartCoroutine(FadeToGreen(mine));
                }
            }
            if (actionName == "Stop left")
            {
                StartCoroutine(FadeToGreen(left));
            }
            if (actionName == "Stop right")
            {
                StartCoroutine(FadeToGreen(right));
            }
        }
       
    }

    IEnumerator FadeToGrey(SpriteRenderer rd)
    {
        yield return new WaitForSeconds(0.3f);
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            rd.color = Color.Lerp(rd.color, disabled, i);
            yield return null;
        }
    }

    IEnumerator FadeToRed(SpriteRenderer rd)
    {
        // loop over 1 second backwards
        for (float i = 0.5f; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            rd.color = Color.Lerp(rd.color, pressed, i*2);
            yield return null;
        }
    }
    IEnumerator FadeToGreen(SpriteRenderer rd)
    {
        yield return new WaitForSeconds(0.5f);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            rd.color = Color.Lerp(rd.color, normal, i);
            yield return null;
        }
    }
}
