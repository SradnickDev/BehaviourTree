using Units.General;
using UnityEngine;

namespace Units.Types
{
	[RequireComponent(typeof(UnitMovementAction))]
	public class Unit : MonoBehaviour
	{
		public UnitMovementAction MovementAction = null;

		protected virtual void Start()
		{
			MovementAction = GetComponent<UnitMovementAction>();
		}
	}
}