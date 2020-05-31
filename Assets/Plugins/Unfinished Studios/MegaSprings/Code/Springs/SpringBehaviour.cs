using UnityEngine;

namespace UnfinishedStudios.MegaSprings
{
    public class SpringBehaviour : MonoBehaviour
    {
        [Header("Spring")]

        public Vector3 Spring = new Vector3(0.5f, 0.5f, 0.5f);
        public Vector3 Damping = new Vector3(15, 15, 15);

		[Header("Debug")]

		[ReadOnly]
        public Vector3[] Velocities = new Vector3[3];
		
		[ReadOnly]
        public Vector3[] Values = new Vector3[3];


        public virtual Vector3 Move() { return Vector3.zero; }
        public virtual Vector3 Rotate() { return Vector3.zero; }
        public virtual Vector3 Scale() { return Vector3.zero; }
    }
}