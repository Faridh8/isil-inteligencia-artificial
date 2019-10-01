using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	void Start()
	{
		Global.agents = new List<Transform>();

		for (int i = 0; i < 10; i++)
		{
			GameObject agent = Instantiate(Resources.Load<GameObject>("Agent"));
			agent.transform.position = Random.insideUnitCircle * Random.Range(1, 5);

			Global.agents.Add(agent.transform);
		}
	}
}
