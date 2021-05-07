using UnityEngine;

namespace Recorder
{
    public class TimedInput
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