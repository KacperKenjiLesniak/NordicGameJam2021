using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Audio;
using MutableObjects.Float;
using Recorder;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    public Queue<TimedInput> inputQueue = new Queue<TimedInput>();
    
    public MutableFloat currentRecordingTime;
    public Countdown countdown;

    private PlayerMovement playerMovement;
    private AudioManager audioManager;
    public bool musicActive = true;
    
    private void Awake()
    {
        countdown = FindObjectOfType<Countdown>();
        playerMovement = GetComponent<PlayerMovement>();
        audioManager = FindObjectOfType<AudioManager>();
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
                    if (musicActive) audioManager.PlayClip(2);
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
            Debug.Log("Enqueued " + input);
            if (input == InputType.JUMP)
            {
                if (musicActive) audioManager.PlayClip(2);
            }
            inputQueue.Enqueue(new TimedInput(currentRecordingTime.Value, input));
        }
        else if (countdown.recordingState == RecordingState.BREAK &&
                 (input == InputType.RUN_LEFT_START || input == InputType.RUN_RIGHT_START))
        {
            inputQueue.Clear();
            Debug.Log("Enqueued during break " + input);
            inputQueue.Enqueue(new TimedInput(0f, input));
        }
    }

    public void ClearInputQueue()
    {
        inputQueue.Clear();
    }
}
