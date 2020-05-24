using UnityEngine;

namespace BehaviourTree.General
{
	public abstract class Behaviour : MonoBehaviour
	{
		protected Node BehaviourTree;
		protected BehaviourInfo BehaviourInfo;

		public abstract Node Tree();
	}
}