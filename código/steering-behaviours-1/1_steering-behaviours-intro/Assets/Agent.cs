using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
	Vector3 velocity;
	Vector3 desiredSeek;
	Vector3 desiredFlee;
	Vector3 desired;
	Vector3 steer;

	[SerializeField]
	float MAX_FORCE = 3f;
	[SerializeField]
	float MAX_STEER = 0.5f;

	[SerializeField]
	float SEEK_RANGE = 3;
	[SerializeField]
	float FLEE_RANGE = 3;

	void Update()
	{
		// seek
		Vector3 targetSeek = GameObject.Find("Mouse").transform.position;
		desiredSeek = (targetSeek - transform.position).normalized * MAX_FORCE;
	
		// flee
		Vector3 targetRandom = GameObject.Find("Random").transform.position;
		float distanceRandom = (targetRandom - transform.position).magnitude;

		if (distanceRandom < FLEE_RANGE)
		{
			desiredFlee = -(targetRandom - transform.position).normalized * MAX_FORCE;
		}
		else
		{
			desiredFlee = Vector3.zero;
		}

		// sumando:

		desired = desiredSeek + desiredFlee;

		steer = Vector3.ClampMagnitude(desired - velocity, MAX_STEER);
		velocity += steer;
		transform.position += velocity * Time.deltaTime;
	}
}
