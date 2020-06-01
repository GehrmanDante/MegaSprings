using UnityEngine;

namespace UnfinishedStudios.MegaSprings
{
    public class Spring : MonoBehaviour
    {
        [ReadOnly]
        [SerializeField]
        private SpringBehaviour[] behaviours;

        private Vector3[] restTransform = new Vector3[3];

        private void Awake()
        {
            //Save the rest position.
            restTransform[0] = transform.localPosition;
            restTransform[1] = transform.localEulerAngles;
            restTransform[2] = transform.localScale;

            //Get all the spring behaviours.
            behaviours = GetComponents<SpringBehaviour>();
        }

        private void Update()
        {
            Vector3[] newTransform = new Vector3[3];
            for (int i = 0; i < behaviours.Length; i++)
            {
                SpringBehaviour behaviour = behaviours[i];
                if (behaviour.Disable)
                    continue;

                //Add the new velocities.
                Vector3[] velocities = behaviour.Velocities;
                velocities[0] += behaviour.Move();
                velocities[1] += behaviour.Rotate();
                velocities[2] += behaviour.Scale();

                //Add to the new transform.
                Solve(behaviour);
                Vector3[] values = behaviour.Values;
                newTransform[0] += values[0];
                newTransform[1] += values[1];
                newTransform[2] += values[2];
            }

            //Apply the new transform.
            transform.localPosition = restTransform[0] + newTransform[0];
            transform.localEulerAngles = restTransform[1] + newTransform[1];
            transform.localScale = restTransform[2] + newTransform[2];
        }

        private void Solve(SpringBehaviour behaviour)
        {
            //Calculate the new velocities.
            for (int i = 0; i < 3; i++)
            {
                Vector3 velocity = behaviour.Velocities[i];
                Vector3 value = behaviour.Values[i];

                //Calculate the new velocity and value.
                velocity = (velocity - value) * behaviour.Spring[i];
                value += velocity * Time.deltaTime * behaviour.Damping[i];

                behaviour.Velocities[i] = velocity;
                behaviour.Values[i] = value;
            }
        }
    }
}