using System;
using UnityEngine;

namespace Recorder
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private string upKey, leftKey, rightKey, weaponKey, interactKey, boostKey;
        private InputRecorder inputRecorder;

        private void Awake()
        {
            inputRecorder = GetComponent<InputRecorder>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(upKey))
            {
                inputRecorder.AddInput(InputType.JUMP);
            }

            if (Input.GetKeyDown(leftKey))
            {
                inputRecorder.AddInput(InputType.RUN_LEFT_START);
            }

            if (Input.GetKeyDown(rightKey))
            {
                inputRecorder.AddInput(InputType.RUN_RIGHT_START);
            }

            if(Input.GetKeyUp(leftKey))
            {
                inputRecorder.AddInput(InputType.RUN_LEFT_STOP);
            }

            if(Input.GetKeyUp(rightKey))
            {
                inputRecorder.AddInput(InputType.RUN_RIGHT_STOP);
            }

            if (Input.GetKeyDown(weaponKey))
            {
                inputRecorder.AddInput(InputType.WEAPON);
            }

            if (Input.GetKeyDown(interactKey))
            {
                inputRecorder.AddInput(InputType.INTERACT);
            }

            if (Input.GetKeyDown(boostKey))
            {
                inputRecorder.AddInput(InputType.BOOST);
            }
        }
    }
}