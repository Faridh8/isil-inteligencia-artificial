using UnityEngine;

public class Agent : SBAgent
{
	public Transform target;
	public Transform target2;

	void Start()
	{
		maxSpeed = 10f;
		maxSteer = 0.5f;

		target2 = GameObject.Find("Target2").transform;
	}

	void Update()
	{
		velocity += SteeringBehaviours.Arrive(this, target, 3);
		velocity += SteeringBehaviours.Flee(this, target2, 1);
		velocity += SteeringBehaviours.Separate(this, GameManager.agents, 2f);
		transform.position += velocity * Time.deltaTime;
	}
}
