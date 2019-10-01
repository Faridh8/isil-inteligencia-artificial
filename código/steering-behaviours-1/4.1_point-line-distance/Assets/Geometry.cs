using UnityEngine;

static public class Geometry
{
	static public Vector3 PointLineIntersection(Vector3 P, Vector3 A, Vector3 B)
	{
		Vector3 u = (B - A).normalized;
		Vector3 D = u * Vector3.Dot(P - A, u);
		Vector3 Q = A + D;

		// cálculo del ángulo PAB
		float anglePAB = Mathf.Acos(Vector3.Dot(P - A, B - A) / ((P - A).magnitude * (B - A).magnitude));
		
		// cálculo del ángulo PBA
		float anglePBA = Mathf.Acos(Vector3.Dot(P - B, A - B) / ((P - B).magnitude * (A - B).magnitude));
		
		if (anglePAB > Mathf.PI / 2) return A;
		if (anglePBA > Mathf.PI / 2) return B;

		return Q;
	}
}
