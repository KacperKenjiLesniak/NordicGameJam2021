using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;

public class RotateObstacle : MonoBehaviour
{
    public float degreesPerSec = 360f;
    public bool isRotating = true;
    private Vector3 resetRotation;
    public Countdown countdown;

    private void Start()
    {
        resetRotation = transform.localRotation.eulerAngles;
        countdown = FindObjectOfType<Countdown>();
    }

    // Update is called once per frame
    void Update()
    {
        resetPosition();
        if (isRotating)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.localRotation.eulerAngles.z + degreesPerSec * Time.deltaTime));
        }
    }

    void resetPosition()
    {
        if (countdown.recordingState == RecordingState.BREAK)
        {
            transform.localRotation = Quaternion.Euler(resetRotation); ;
            isRotating = false;
        }
        else
        {
            isRotating = true;
        }
    }
}

