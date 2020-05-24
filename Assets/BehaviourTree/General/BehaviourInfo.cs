using Units.General;
using Units.Types;

namespace BehaviourTree.General
{
	public class BehaviourInfo : BehaviourState
	{
		public Unit Self = null;
		public Unit TargetUnit = null;
		public UnitMovementAction MovementAction = null;
	}
}