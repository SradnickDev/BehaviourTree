using System.Collections.Generic;
using BehaviourTree.Composite;
using BehaviourTree.Decorator;
using BehaviourTree.General;
using Units.BT.Nodes;
using Units.General;
using Units.Types;
using UnityEngine;
using Behaviour = BehaviourTree.General.Behaviour;

namespace Units.BT
{
	public class ExampleFollowBehaviour : Behaviour
	{
		[SerializeField] private float SearchRadius = 15;

		private void Start()
		{
			BehaviourInfo = new BehaviourInfo
			{
				MovementAction = GetComponent<UnitMovementAction>(),
				Self = GetComponent<Unit>()
			};

			BehaviourTree = Tree();
		}

		private void Update()
		{
			BehaviourTree.Behave(BehaviourInfo);
		}

		public override Node Tree()
		{
			var rndMovement = new Sequence(new SetRandomDestination(SearchRadius),
										   new ReachedDestination());

			var moveToUnit = new Sequence(new GetNearestUnit(SearchRadius * 2),
										  new WaitSeconds(1),
										  new FollowTarget(),
										  new ReachedDestination());


			return new Sequence(moveToUnit, rndMovement);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, SearchRadius);
		}
	}
}