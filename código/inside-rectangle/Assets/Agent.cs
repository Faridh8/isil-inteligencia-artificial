using UnityEngine;

public class Agent : SBAgent
{
	Vector3 desiredSeek;
	Vector3 desiredInsideRectangle;

	Vector3 desired;
	Vector3 steer;

	Vector3 rectangleCenter = Vector3.zero;
	float rectangleWidth = 2;
	float rectangleHeight = 2;

	void Start()
	{
		maxSpeed = 2;
	}

	void Update()
	{
		GameObject target = GameObject.Find("Target");

		// Desired Seek
		desiredSeek = (target.transform.position - transform.position).normalized * maxSpeed;

		// Desired Inside Circle
		if (transform.position.y > rectangleCenter.y + rectangleHeight / 4 ||
            transform.position.y < rectangleCenter.y - rectangleHeight / 4 ||
            transform.position.x > rectangleCenter.x + rectangleWidth / 4 ||
            transform.position.x < rectangleCenter.x - rectangleWidth / 4)
		{
			desiredInsideRectangle = (rectangleCenter - transform.position).normalized * maxSpeed;
		}
		else
		{
			desiredInsideRectangle = Vector3.zero;
		}

		desired = desiredSeek + desiredInsideRectangle;
		steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);
		velocity += steer * Time.deltaTime;
		transform.position += velocity * Time.deltaTime;
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(2, 2, 0));
	}
}
