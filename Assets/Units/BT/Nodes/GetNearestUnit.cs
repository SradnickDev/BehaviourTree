using BehaviourTree.General;
using BehaviourTree.Leaf;
using Units.Types;
using UnityEngine;

namespace Units.BT.Nodes
{
	public class GetNearestUnit : LeafNode
	{
		private const int MaxHits = 20;
		private readonly float m_searchRange = 0;
		private RaycastHit[] m_hits = new RaycastHit[MaxHits];

		public GetNearestUnit(float searchRange)
		{
			m_searchRange = searchRange;
		}

		public override NodeStates OnBehave(BehaviourState state)
		{
			var context = (BehaviourInfo) state;

			var hitCount = GetNearUnitHits(context);
			var closestUnit = GetClosestUnit(hitCount, context);
			if (closestUnit != null)
			{
				context.TargetUnit = closestUnit;
				
				return NodeStates.Success;
			}

			return NodeStates.Failure;
		}

		private Unit GetClosestUnit(int hitCount, BehaviourInfo behaviour)
		{
			var closestDist = Mathf.Infinity;
			Unit target = null;

			for (var i = 0; i < hitCount; i++)
			{
				var t = m_hits[i].transform.GetComponent<Unit>();

				if (t == null || t == behaviour.Self) continue;

				var dist =
					Vector3.Distance(behaviour.Self.transform.position, t.transform.position);

				if (dist < closestDist)
				{
					closestDist = dist;
					target = t;
				}
			}

			return target;
		}

		private int GetNearUnitHits(BehaviourInfo behaviour)
		{
			var hitCount = Physics.SphereCastNonAlloc(behaviour.Self.transform.position,
													  m_searchRange, Vector3.up, m_hits);
			return hitCount;
		}

		public override void OnReset()
		{
			m_hits = new RaycastHit[MaxHits];
		}
	}
}