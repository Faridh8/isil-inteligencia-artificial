using UnityEngine;

public class Agent : SBAgent
{
	public Transform target;

	void Start()
	{
		maxSpeed = 0.5f;
		maxSteer = 0.5f;
	}

	void Update()
	{
		velocity += SteeringBehaviours.Arrive(this, target, 3);
		transform.position += velocity;
	}
}
