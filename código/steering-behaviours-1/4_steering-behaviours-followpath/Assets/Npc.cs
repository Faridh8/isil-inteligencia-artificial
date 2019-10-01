using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class Npc : BaseAgent
{
	int currentIndex = -1;
	Vector3 targetPosition;

	void Start()
	{
		maxForce = 5;
		maxSteer = 0.3f;

		Global.path.Add(GameObject.Find("p1").transform);
		Global.path.Add(GameObject.Find("p2").transform);
		Global.path.Add(GameObject.Find("p3").transform);
		Global.path.Add(GameObject.Find("p4").transform);
		Global.path.Add(GameObject.Find("p5").transform);
		
		SetNextTarget();
	}

	void Update()
	{
		addSeek(targetPosition);

		if (Vector3.Distance(transform.position, targetPosition) < 1)
		{
			SetNextTarget();
		}
	}

	void SetNextTarget()
	{
		currentIndex++; if (currentIndex == Global.path.Count) currentIndex = 0;
		targetPosition = Global.path[currentIndex].position;
	}
}
