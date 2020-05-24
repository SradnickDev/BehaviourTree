using BehaviourTree.General;

namespace BehaviourTree.Decorator
{
	public class Inverter : DecoratorNode
	{
		public Inverter(Node child) : base(child) { }

		public override NodeStates OnBehave(BehaviourState state)
		{
			switch (Child.Behave(state))
			{
				case NodeStates.Running:
					return NodeStates.Running;

				case NodeStates.Success:
					return NodeStates.Failure;

				case NodeStates.Failure:
					return NodeStates.Success;
			}

			return NodeStates.Failure;
		}

		public override void OnReset() { }
	}
}