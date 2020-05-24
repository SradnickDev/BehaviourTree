using BehaviourTree.General;

namespace BehaviourTree.Composite
{
	public class Sequence : CompositeNode
	{
		private int m_currentChild = 0;

		public Sequence(params Node[] nodes) : base(nodes) { }

		public override NodeStates OnBehave(BehaviourState state)
		{
			var retVal = Children[m_currentChild].Behave(state);

			switch (retVal)
			{
				case NodeStates.Success:
					m_currentChild++;
					break;

				case NodeStates.Failure:
					return NodeStates.Failure;
			}

			if (m_currentChild >= Children.Count)
			{
				return NodeStates.Success;
			}
			
			if (retVal == NodeStates.Success)
			{
				return OnBehave(state);
			}

			return NodeStates.Running;
		}

		public override void OnReset()
		{
			m_currentChild = 0;
			foreach (var child in Children)
			{
				child.Reset();
			}
		}
	}
}