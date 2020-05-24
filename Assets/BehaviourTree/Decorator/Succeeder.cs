using BehaviourTree.General;

namespace BehaviourTree.Decorator
{
	public class Succeeder : DecoratorNode
	{
		public Succeeder(Node child) : base(child) { }

		public override NodeStates OnBehave(BehaviourState state)
		{
			var retVal = Child.Behave(state);

			if (retVal == NodeStates.Running)
				return NodeStates.Running;

			return NodeStates.Success;
		}

		public override void OnReset() { }
	}
}