using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class Npc : BaseAgent
{
	void Start()
	{
		maxForce = 2;
		maxSteer = 0.1f;
		velocity = new Vector3(1, 0, 0);
	}

	void Update()
	{
		addWander(2, 0.1f);
	}
}
