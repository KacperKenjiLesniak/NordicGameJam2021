using UnityEngine;

namespace Recorder
{
    public class TimedInput : MonoBehaviour
    {
        public float timestamp;
        public InputType input;

        public TimedInput(float timestamp, InputType input)
        {
            this.timestamp = timestamp;
            this.input = input;
        }
    }
}