using BehaviourTree.General;
using BehaviourTree.Leaf;
using UnityEngine.AI;

namespace Units.BT.Nodes
{
	public class ReachedDestination : LeafNode
	{
		public override NodeStates OnBehave(BehaviourState state)
		{
			var context = (BehaviourInfo) state;
			var agent = context.Self.MovementAction.Agent;

			if (context.MovementAction.ReachedDestination())
			{
				return NodeStates.Success;
			}

			if (agent.pathPending || agent.hasPath)
			{
				return NodeStates.Running;
			}

			if (agent.path.status == NavMeshPathStatus.PathInvalid || agent.path.status == NavMeshPathStatus.PathPartial)
			{
				return NodeStates.Failure;
			}

			return NodeStates.Running;
		}

		public override void OnReset() { }
	}
}