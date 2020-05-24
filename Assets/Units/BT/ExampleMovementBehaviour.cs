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
	public class ExampleMovementBehaviour : Behaviour
	{
		[SerializeField] private float RandomPositionRadius = 15;
		[SerializeField] private List<Transform> PatrolPoints = new List<Transform>();

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
			var movement = new Sequence(new SetRandomDestination(RandomPositionRadius),
										new ReachedDestination(),
										new WaitSeconds(1),
										new Patrol(PatrolPoints, transform.position),
										new ReachedDestination(),
										new WaitSeconds(1));

			var repeatPatrol = new Repeater(movement);
			var walking = new Sequence(repeatPatrol);
			return walking;
		}
	}
}