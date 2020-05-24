using Units.Types;
using UnityEngine;
using UnityEngine.AI;

namespace Units.General
{
	[RequireComponent(typeof(Animator))]
	public class UnitView : MonoBehaviour
	{
		[SerializeField] private NavMeshAgent Agent = null;
		[SerializeField] private Unit Owner = null;
		private Animator m_animator = null;
		private readonly int m_moveHash = Animator.StringToHash("Move");
		private readonly int m_attackHash = Animator.StringToHash("Attack");

		private void Start()
		{
			m_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			var velocity = Agent.velocity.magnitude;

			//m_animator.SetFloat(m_moveHash, Mathf.Clamp01(velocity));
		}

		public void Attack()
		{
			m_animator.SetTrigger(m_attackHash);
		}

		public bool InState(int layerIdx, string stateName)
		{
			return m_animator.GetCurrentAnimatorStateInfo(layerIdx).IsName(stateName);
		}
	}
}