using System.Collections.Generic;
using BehaviourTree.General;
using BehaviourTree.Leaf;
using UnityEngine;

namespace Units.BT.Nodes
{
	public class Patrol : LeafNode
	{
		private List<Transform> m_patrolPoints = null;
		private int m_currentPoint = 0;

		public Patrol(List<Transform> points, Vector3 startPoint)
		{
			m_patrolPoints = points;

			//get nearest patrol point
			var nearestDist = Mathf.Infinity;
			for (var i = 0; i < points.Count; i++)
			{
				var point = points[i];
				var distToPoint = Vector3.Distance(point.position, startPoint);

				if (distToPoint < nearestDist)
				{
					nearestDist = distToPoint;
					m_currentPoint = i;
				}
			}
		}

		public override NodeStates OnBehave(BehaviourState state)
		{
			var context = (BehaviourInfo) state;

			m_currentPoint = (m_currentPoint + 1) % m_patrolPoints.Count;
			var nextPoint = m_patrolPoints[m_currentPoint];

			if (context.MovementAction.MoveTo(nextPoint.position))
			{
				return NodeStates.Success;
			}

			return NodeStates.Failure;
		}

		public override void OnReset() { }
	}
}