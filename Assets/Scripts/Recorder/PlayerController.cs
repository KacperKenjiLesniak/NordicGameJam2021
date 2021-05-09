using System;
using UnityEngine;

namespace Recorder
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private string upKey, leftKey, rightKey, weaponKey, interactKey, boostKey;
        private InputRecorder inputRecorder;
        private InputFeedback inputFeedback;

        private void Awake()
        {
            inputRecorder = GetComponent<InputRecorder>();
            inputFeedback = GetComponent<InputFeedback>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(upKey))
            {
                inputFeedback.ShowFeedback("Jump");
                inputRecorder.AddInput(InputType.JUMP);
            }

            if (Input.GetKeyDown(leftKey))
            {
                inputFeedback.ShowFeedback("Left");
                inputRecorder.AddInput(InputType.RUN_LEFT_START);
            }

            if (Input.GetKeyDown(rightKey))
            {
                inputFeedback.ShowFeedback("Right");
                inputRecorder.AddInput(InputType.RUN_RIGHT_START);
            }

            if(Input.GetKeyUp(leftKey))
            {
                inputFeedback.ShowFeedback("Stop left");
                inputRecorder.AddInput(InputType.RUN_LEFT_STOP);
            }

            if(Input.GetKeyUp(rightKey))
            {
                inputFeedback.ShowFeedback("Stop right");
                inputRecorder.AddInput(InputType.RUN_RIGHT_STOP);
            }

            if (Input.GetKeyDown(weaponKey))
            {
                inputFeedback.ShowFeedback("Dropped mine");
                inputRecorder.AddInput(InputType.WEAPON);
            }

            if (Input.GetKeyDown(interactKey))
            {
                inputFeedback.ShowFeedback("Interact");
                inputRecorder.AddInput(InputType.INTERACT);
            }

            if (Input.GetKeyDown(boostKey))
            {
                inputFeedback.ShowFeedback("boost");
                inputRecorder.AddInput(InputType.BOOST);
            }
        }
    }
}