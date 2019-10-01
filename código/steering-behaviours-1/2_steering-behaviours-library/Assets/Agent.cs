using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class Agent : BaseAgent
{
	[SerializeField]
	float FLEE_RANGE = 1;

	void Start()
	{
		maxForce = 2;
		maxSteer = 0.8f;
	}

	void Update()
	{

		Vector3 mousePosition = GameObject.Find("Mouse").transform.position;
		Vector3 randomPosition = GameObject.Find("Random").transform.position;

		addArrive(mousePosition, 2, 3);
		addFlee(randomPosition, FLEE_RANGE);
		calculate();
	}
}
