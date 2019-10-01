using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMotion : MonoBehaviour
{
	Vector3 velocity = new Vector3(3, 0, 0);
	Vector3 desired;
	Vector3 steer;

	float MAX_FORCE = 2.5f;
	float MAX_STEER = 0.3f;

	Vector3 target;
	float timer = 0;

	void Start()
	{
		randomizeTarget();
	}

	void Update()
	{
		desired = (target - transform.position).normalized * MAX_FORCE;
		steer = Vector3.ClampMagnitude(desired - velocity, MAX_STEER) * MAX_STEER;
		velocity += steer;
		transform.position += velocity * Time.deltaTime;

		timer += Time.deltaTime;
		if (timer >= 3)
		{
			timer = 0;
			randomizeTarget();
		}
	}

	void randomizeTarget()
	{
		float x = Random.Range(-5, 5);
		float y = Random.Range(-5, 5);

		target = new Vector3(x, y, 0);
	}
}
