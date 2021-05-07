using System;
using UnityEngine;

namespace Recorder
{
    public class TempPlayerController : MonoBehaviour
    {
        private InputRecorder inputRecorder;
        
        private void Awake()
        {
            inputRecorder = GetComponent<InputRecorder>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                inputRecorder.AddInput(InputType.RUN_LEFT_START);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                inputRecorder.AddInput(InputType.RUN_RIGHT_START);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                inputRecorder.AddInput(InputType.JUMP);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                inputRecorder.AddInput(InputType.RUN_LEFT_STOP);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                inputRecorder.AddInput(InputType.RUN_RIGHT_STOP);
            }
        }
    }
}