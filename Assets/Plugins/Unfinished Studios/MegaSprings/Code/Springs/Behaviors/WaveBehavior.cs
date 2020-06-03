using UnityEngine;
using System;

namespace UnfinishedStudios.MegaSprings
{
    public enum WaveSetting
    {
        Default,
        IgnoreZero,
        Absolute,
        Smooth
    }

    public class WaveBehavior : SpringBehavior
    {
        [Header("Sine Wave")]

        [SerializeField]
        private WaveSetting setting;

        [SerializeField]
        private Vector3[] speed = new Vector3[3];

        [SerializeField]
        private Vector3[] amplitude = new Vector3[3];

        private Vector3 Wave(int index)
        {
            //Save for cleaner code.
            Vector3 localAmplitude = amplitude[index];
            Vector3 localSpeed = speed[index];

            //Calculate a sine wave.
            Vector3 value = Vector3.zero;
            value.x = Mathf.Sin(Time.time * localSpeed.x) * localAmplitude.x;
            value.y = Mathf.Sin(Time.time * localSpeed.y) * localAmplitude.y;
            value.z = Mathf.Sin(Time.time * localSpeed.z) * localAmplitude.z;

            //Change how the value works depending on the setting.
            switch (setting)
            {
                case WaveSetting.Default:
                    value = Round(value, 0);
                    break;
                case WaveSetting.Absolute:
                    value = Absolute(value);
                    break;
                case WaveSetting.IgnoreZero:
                    value.y = (value.y > 0) ? localAmplitude.y : -localAmplitude.y;
                    break;
                default:
                    break;
            }

            return value;
        }

        private Vector3 Round(Vector3 value, int digits)
        {
            Vector3 finalValue = value;
            finalValue.x = (float)Math.Round(value.x, digits);
            finalValue.y = (float)Math.Round(value.y, digits);
            finalValue.z = (float)Math.Round(value.z, digits);

            return finalValue;
        }

        private Vector3 Absolute(Vector3 value)
        {
            Vector3 finalValue = value;
            finalValue.x = Mathf.Abs(finalValue.x);
            finalValue.y = Mathf.Abs(finalValue.y);
            finalValue.z = Mathf.Abs(finalValue.z);

            return finalValue;
        }

        public override Vector3 Move() { return Wave(0); }

        public override Vector3 Rotate() { return Wave(1); }

        public override Vector3 Scale() { return Wave(2); }
    }
}