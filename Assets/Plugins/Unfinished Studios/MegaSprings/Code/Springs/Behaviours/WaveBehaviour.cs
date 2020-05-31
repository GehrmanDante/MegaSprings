using UnityEngine;
using System;

namespace UnfinishedStudios.MegaSprings
{
    [RequireComponent(typeof(Spring))]
    public class WaveBehaviour : SpringBehaviour
    {
        [Header("Sine Wave")]

        [SerializeField]
        private Vector3[] speed = new Vector3[3];

        [SerializeField]
        private Vector3[] amplitude = new Vector3[3];

        [SerializeField]
        private Vector3[] steps = new Vector3[3];

        private Vector3 Wave(int index)
        {
            //Save for cleaner code.
            Vector3 localAmplitude = amplitude[index];
            Vector3 localSpeed = speed[index];
            Vector3 localStep = steps[index];

            //Calculate a sine wave.
            Vector3 value = Vector3.zero;
            value.x = Step(Mathf.Sin(Time.time * localSpeed.x) * localAmplitude.x, localAmplitude.x, localStep.x);
            value.y = Step(Mathf.Sin(Time.time * localSpeed.y) * localAmplitude.y, localAmplitude.y, localStep.y);
            value.z = Step(Mathf.Sin(Time.time * localSpeed.z) * localAmplitude.z, localAmplitude.z, localStep.z);

            return value;
        }

        private float Step(float value, float amplitude, float localStep)
        {
            //No reason to calculate if amplitude is zero.
            if(amplitude == 0 || localStep == 0)
                return value;

            //Round.
            float step = (float)(localStep / amplitude);
            return (float)(Math.Round(value * step) / step);
        }

        public override Vector3 Move() { return Wave(0); }

        public override Vector3 Rotate() { return Wave(1); }

        public override Vector3 Scale() { return Wave(2); }
    }
}