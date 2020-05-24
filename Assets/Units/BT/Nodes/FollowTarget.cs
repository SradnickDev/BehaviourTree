using BehaviourTree.General;
using BehaviourTree.Leaf;

namespace Units.BT.Nodes
{
	public class FollowTarget : LeafNode
	{
		public override NodeStates OnBehave(BehaviourState state)
		{
			var context = (BehaviourInfo) state;


			if (context.TargetUnit != null)
			{
				context.MovementAction.FollowTarget(context.TargetUnit);
				return NodeStates.Success;
			}

			return NodeStates.Failure;
		}

		public override void OnReset() { }
	}
}