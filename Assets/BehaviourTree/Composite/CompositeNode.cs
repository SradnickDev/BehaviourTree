using System.Collections.Generic;
using BehaviourTree.General;

namespace BehaviourTree.Composite
{
	public abstract class CompositeNode : Node
	{
		protected List<Node> Children = new List<Node>();

		protected CompositeNode(params Node[] nodes)
		{
			Children.AddRange(nodes);
		}

		public override NodeStates Behave(BehaviourState state)
		{
			var retVal = base.Behave(state);
			return retVal;
		}
	}
}