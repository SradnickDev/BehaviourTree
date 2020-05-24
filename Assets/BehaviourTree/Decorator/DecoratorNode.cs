using BehaviourTree.General;

namespace BehaviourTree.Decorator
{
	public abstract class DecoratorNode : Node
	{
		protected Node Child;

		public DecoratorNode(Node node)
		{
			Child = node;
		}
	}
}