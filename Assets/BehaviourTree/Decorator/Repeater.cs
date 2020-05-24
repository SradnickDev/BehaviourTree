using BehaviourTree.General;

namespace BehaviourTree.Decorator
{
	public class Repeater : DecoratorNode
	{
		public Repeater(Node child) : base(child) { }

		public override NodeStates OnBehave(BehaviourState state)
		{
			var retVal = Child.Behave(state);
			if (retVal != NodeStates.Running)
			{
				Reset();
				Child.Reset();
			}

			return NodeStates.Success;
		}

		public override void OnReset() { }
	}
}