using UnityEngine;

namespace UnfinishedStudios.MegaSprings
{
    public class Spring : MonoBehaviour
    {
        [ReadOnly]
        [SerializeField]
        private SpringBehavior[] behaviors;

        private Vector3[] restTransform = new Vector3[3];

        private void Awake()
        {
            //Save the rest position.
            restTransform[0] = transform.localPosition;
            restTransform[1] = transform.localEulerAngles;
            restTransform[2] = transform.localScale;

            //Get all the spring behaviours.
            behaviors = GetComponents<SpringBehavior>();
        }

        private void Update()
        {
            //Calculate the new transform by adding transforms from each behavior.
            Vector3[] newTransform = new Vector3[3];
            Loops.ForEach(behaviors, (behavior) =>
            {
                Vector3[] values = UpdateBehavior(behavior);
                newTransform[0] += values[0];
                newTransform[1] += values[1];
                newTransform[2] += values[2];
            });

            //Apply the new transform.
            transform.localPosition = restTransform[0] + newTransform[0];
            transform.localEulerAngles = restTransform[1] + newTransform[1];
            transform.localScale = restTransform[2] + newTransform[2];
        }

        private Vector3[] UpdateBehavior(SpringBehavior behavior)
        {
            if (behavior.Disable)
                return new Vector3[3];

            //Add the new velocities.
            Vector3[] velocities = behavior.Velocities;
            velocities[0] += behavior.Move();
            velocities[1] += behavior.Rotate();
            velocities[2] += behavior.Scale();

            //Add to the new transform.
            Solve(behavior);
            return behavior.Values;
        }

        private void Solve(SpringBehavior behavior)
        {
            //Calculate the new velocities.
            for (int i = 0; i < 3; i++)
            {
                Vector3 velocity = behavior.Velocities[i];
                Vector3 value = behavior.Values[i];

                //Calculate the new velocity and value.
                velocity = (velocity - value) * behavior.Spring[i];
                value += velocity * Time.deltaTime * behavior.Damping[i];

                behavior.Velocities[i] = velocity;
                behavior.Values[i] = value;
            }
        }
    }
}