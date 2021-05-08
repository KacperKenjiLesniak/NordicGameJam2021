using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;
using UnityEngine.UI;
using TMPro;

public class InputFeedback : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentAction, lastAction, thirdAction;
    public Countdown countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = FindObjectOfType<Countdown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.recordingState == RecordingState.PLAYING)
        {
            currentAction.gameObject.SetActive(false);
            lastAction.gameObject.SetActive(false);
            thirdAction.gameObject.SetActive(false);

        }

        if (countdown.recordingState == RecordingState.RECORDING)
        {
            currentAction.gameObject.SetActive(true);
            lastAction.gameObject.SetActive(true);
            thirdAction.gameObject.SetActive(true);
        }
    }

    public void ShowFeedback(string actionName)
    {
        thirdAction.text = lastAction.text;
        lastAction.text = currentAction.text;
        currentAction.text = actionName;
    }

}
