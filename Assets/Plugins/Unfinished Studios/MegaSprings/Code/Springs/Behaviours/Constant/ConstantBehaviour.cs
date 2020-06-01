using UnityEngine;

namespace UnfinishedStudios.MegaSprings
{
    public class ConstantBehaviour : SpringBehaviour
    {
        [Header("Movement Settings")]

        [SerializeField]
        protected Vector3[] forces = new Vector3[3];

        [SerializeField]
        protected Vector3[] maxValues = new Vector3[3];

        protected virtual Vector3 ProduceForce(int index)
        {
            //Save values for convenience.
            Vector3 localForce = forces[index];
            Vector3 localMax = maxValues[index];

            //Clamp the values.
            Values[index] = ResetVector(Values[index], localMax);
            return Values[index] + localForce;
        }

        protected Vector3 ResetVector(Vector3 localForce, Vector3 localMax)
        {
            //Reset all the values so that they don't eventually overflow.
            Vector3 finalForce = localForce;
            finalForce.x = ResetFloat(finalForce.x, localMax.x);
            finalForce.y = ResetFloat(finalForce.y, localMax.y);
            finalForce.z = ResetFloat(finalForce.z, localMax.z);

            return finalForce;
        }

        protected float ResetFloat(float force, float max)
        {
            if(max == 0)
                return force;

            //Make sure the value isn't above the max.
            float finalForce = force;
            if (Mathf.Abs(finalForce) >= max)
                finalForce = 0;

            return finalForce;
        }

        public override Vector3 Move() { return ProduceForce(0); }

        public override Vector3 Rotate() { return ProduceForce(1); }

        public override Vector3 Scale() { return ProduceForce(2); }
    }
}