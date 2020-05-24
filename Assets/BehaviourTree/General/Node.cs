
namespace BehaviourTree.General
{
	public abstract class Node
	{
		public virtual NodeStates Behave(BehaviourState state)
		{
			var retVal = OnBehave(state);
			
			if (retVal != NodeStates.Running)
				Reset();

			return retVal;
		}

		public abstract NodeStates OnBehave(BehaviourState state);

		public void Reset()
		{
			OnReset();
		}

		public abstract void OnReset();
	}
}