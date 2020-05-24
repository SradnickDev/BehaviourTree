using BehaviourTree.General;
using BehaviourTree.Leaf;
using UnityEngine;

namespace Units.BT.Nodes
{
	public class WaitSeconds : LeafNode
	{
		private readonly float m_maxSeconds = 0.0f;
		private float m_currentSeconds = 0.0f;

		public WaitSeconds(float time)
		{
			m_maxSeconds = time;
		}

		public override NodeStates OnBehave(BehaviourState state)
		{
			m_currentSeconds += Time.deltaTime;

			if (m_currentSeconds <= m_maxSeconds)
			{
				return NodeStates.Running;
			}
			else
			{
				return NodeStates.Success;
			}
		}

		public override void OnReset()
		{
			m_currentSeconds = 0.0f;
		}
	}
}