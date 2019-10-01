using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
	void Update()
	{
		Vector3 A = GameObject.Find("A").transform.position;
		Vector3 B = GameObject.Find("B").transform.position;
		Vector3 P = GameObject.Find("P").transform.position;

		transform.position = Geometry.PointLineIntersection(P, A, B);
	}
}