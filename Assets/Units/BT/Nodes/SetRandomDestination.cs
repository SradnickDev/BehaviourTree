using BehaviourTree.General;
using BehaviourTree.Leaf;
using UnityEngine;

namespace Units.BT.Nodes
{
	public class SetRandomDestination : LeafNode
	{
		private float m_range = 0.0f;

		public SetRandomDestination(float range)
		{
			m_range = range;
		}

		public override NodeStates OnBehave(BehaviourState state)
		{
			var context = (BehaviourInfo) state;
			var randomPosition = new Vector3(Random.Range(-m_range, m_range), 0, Random.Range(-m_range, m_range));
			var targetPosition = context.Self.transform.position + randomPosition;

			if (context.MovementAction.MoveTo(targetPosition))
			{
				return NodeStates.Success;
			}

			return NodeStates.Failure;
		}

		public override void OnReset() { }
	}
}