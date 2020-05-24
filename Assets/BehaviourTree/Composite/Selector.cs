using BehaviourTree.General;

namespace BehaviourTree.Composite
{
	public class Selector : CompositeNode
	{
		private int m_currentChild = 0;

		public Selector(params Node[] nodes) : base(nodes) { }

		public override NodeStates OnBehave(BehaviourState state)
		{
			if (m_currentChild >= Children.Count)
			{
				return NodeStates.Failure;
			}

			var retVal = Children[m_currentChild].Behave(state);

			switch (retVal)
			{
				case NodeStates.Success:
					return NodeStates.Success;

				case NodeStates.Failure:
					m_currentChild++;

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