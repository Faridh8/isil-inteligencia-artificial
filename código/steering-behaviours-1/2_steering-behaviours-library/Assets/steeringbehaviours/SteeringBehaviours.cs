using UnityEngine;

namespace AI
{
	static public class SteeringBehaviours
	{
		static public Vector3 seek(BaseAgent agent, Vector3 targetPosition, float range = 999999)
		{
			Vector3 desired;
			Vector3 difference = targetPosition - agent.transform.position;
			
			if (difference.magnitude < range)
			{
				desired = difference.normalized * agent.maxForce;
			}
			else
			{
				desired = Vector3.zero;
			}

			return desired;
		}

		static public Vector3 arrive(BaseAgent agent, Vector3 targetPosition, float arriveRange, float range = 999999)
		{
			Vector3 desired;
			Vector3 difference = targetPosition - agent.transform.position;
			float distance = difference.magnitude;

			// rango de funcionamiento general
			if (distance < range)
			{
				// rango de arrive
				if (distance > arriveRange)
				{
					desired = difference.normalized * agent.maxForce;
				}
				else
				{
					desired = difference * agent.maxForce;
				}
			}
			else
			{
				desired = Vector3.zero;
			}

			return desired;
		}

		static public Vector3 flee(BaseAgent agent, Vector3 targetPosition, float range = 999999)
		{
			Vector3 desired;
			Vector3 difference = targetPosition - agent.transform.position;

			if (difference.magnitude < range)
			{
				desired = -difference.normalized * agent.maxForce;
			}
			else
			{
				desired = Vector3.zero;
			}

			return desired;
		}

		static Vector3 randomTargetPosition = Vector3.zero;
		static float timer = 0;

		static public Vector3 random(Agent agent, Vector3 position, float radius, float frequency)
		{
			timer += Time.deltaTime;

			if (timer >= frequency)
			{
				timer = 0;
				randomTargetPosition = (Vector2)position + Random.insideUnitCircle * Random.Range(0, radius);
			}

			return seek(agent, randomTargetPosition);
		}
	}
}