using Units.Types;
using UnityEngine;
using UnityEngine.AI;

namespace Units.General
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class UnitMovementAction : MonoBehaviour
	{
		public bool Stop
		{
			get { return Agent.isStopped; }
			set { Agent.isStopped = value; }
		}

		public NavMeshAgent Agent = null;
		public float InteractionRange = 20;

		private bool m_follow = false;
		private Unit m_owner = null;
		private Unit m_target = null;
		private Vector3 m_targetPosition = new Vector3(0, 0, 0);

		private void Start()
		{
			Agent = GetComponent<NavMeshAgent>();
			m_owner = GetComponent<Unit>();
		}

		private void Update()
		{
			if (m_target == null)
			{
				m_follow = false;
			}

			FollowTarget();
		}

		private void FollowTarget()
		{
			if (m_target == null)
			{
				m_follow = false;
			}

			if (m_follow)
			{
				SetDestination(m_target.transform.position);
			}
		}

		private void LookAt()
		{
			if (m_target == null) return;

			Agent.transform.LookAt(m_target.transform);
		}

		public bool ReachedDestination()
		{
			if (m_follow && m_target == null) return false;
			var targetPos = m_follow ? m_target.transform.position : m_targetPosition;
			var dist = Vector3.Distance(transform.position, targetPos);

			return dist <= InteractionRange;
		}

		public bool MoveTo(Vector3 targetPosition)
		{
			m_follow = false;
			Stop = false;
			m_targetPosition = targetPosition;

			return SetDestination(targetPosition);
		}

		public void FollowTarget(Unit target)
		{
			if (target == null) return;
			m_target = target;
			Stop = false;
			m_follow = true;
		}

		private bool SetDestination(Vector3 position)
		{
			var retVal = Agent.SetDestination(position);
			if (Agent.remainingDistance <= Agent.stoppingDistance)
			{
				LookAt();
			}

			return retVal;
		}
	}
}