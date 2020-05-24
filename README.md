# BehaviourTree
I used this Behaviour Tree in an RTS i made for a while.
Contains some basic Examples.

Tree creations looks like this.
```cs
public override Node Tree()
{
	var movement = new Sequence(new SetRandomDestination(RandomPositionRadius),
								new ReachedDestination(),
								new WaitSeconds(1),
								new Patrol(PatrolPoints, transform.position),
								new ReachedDestination(),
								new WaitSeconds(1));
	var reapatMovement = new Repeater(movement);
	return new Sequence(reapatMovement)
```