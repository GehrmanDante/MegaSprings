using UnityEngine;

namespace UnfinishedStudios.MegaSprings
{
    public class CarBehaviour : ConstantBehaviour
    {
        [SerializeField]
        private Transform rotator;

        protected override Vector3 ProduceForce(int index)
        {
            if (rotator == null)
                return Vector3.zero;

            //Save values for convenience.
            Vector3 localForce = forces[index];
            Vector3 localMax = maxValues[index];

            //Clamp the values.
            Values[index] = ResetVector(Values[index], localMax);
            return Values[index] + (rotator.rotation * forces[index]);
        }
    }
}