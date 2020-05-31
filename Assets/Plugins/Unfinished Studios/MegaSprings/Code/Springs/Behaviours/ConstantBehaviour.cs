using UnityEngine;

namespace UnfinishedStudios.MegaSprings
{
	public class ConstantBehaviour : SpringBehaviour
	{
		[Header("Movement Settings")]

		[SerializeField]
		private Vector3[] forces = new Vector3[3];

		private Vector3 ProduceForce(int index) { return Values[index] + forces[index]; }

		public override Vector3 Move() { return ProduceForce(0); }

		public override Vector3 Rotate() { return ProduceForce(1); }

		public override Vector3 Scale() { return ProduceForce(2); }
	}
}