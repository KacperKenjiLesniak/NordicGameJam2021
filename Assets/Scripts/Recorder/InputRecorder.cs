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

    private PlayerMovement playerMovement;
    
    private void Awake()
    {
        countdown = FindObjectOfType<Countdown>();
        playerMovement = GetComponent<PlayerMovement>();
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
            switch (timedInput.input)
            {
                case InputType.JUMP:
                    playerMovement.Jump();
                    break;
                case InputType.RUN_LEFT_START:
                    playerMovement.MoveLeft();
                    break;
                case InputType.RUN_LEFT_STOP:
                    playerMovement.StopMovement();
                    break;
                case InputType.RUN_RIGHT_START:
                    playerMovement.MoveRight();
                    break;
                case InputType.RUN_RIGHT_STOP:
                    playerMovement.StopMovement();
                    break;
                case InputType.WEAPON:
                    playerMovement.ImplementWeapon();
                    break;
                case InputType.INTERACT:
                    playerMovement.Interact();
                    break;
                case InputType.BOOST:
                    playerMovement.BoostSpeed();
                    break;
            }
        }
    }

    public void AddInput(InputType input)
    {
        if (countdown.recordingState == RecordingState.RECORDING)
        {
            inputQueue.Enqueue(new TimedInput(currentRecordingTime.Value, input));
        }
        else if (countdown.recordingState == RecordingState.BREAK &&
                 (input == InputType.RUN_LEFT_START || input == InputType.RUN_RIGHT_START))
        {
            inputQueue.Clear();
            inputQueue.Enqueue(new TimedInput(0f, input));
        }
    }
}
