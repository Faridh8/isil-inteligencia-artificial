using UnityEngine;

public class Agent : MonoBehaviour
{
    Vector3 targetPosition;
    float timer = 0;
    float TELEPORT_TIME = 1;

    Vector3 velocity = Vector3.zero;
    Vector3 desired = Vector3.zero;
    Vector3 steer = Vector3.zero;
    float maxSteer = 10;
    float maxSpeed = 10;

    void Start()
    {
        RandomizePosition();
    }

    void Update()
    {
        if (timer > TELEPORT_TIME) {
            timer = 0;
            RandomizePosition();
        }

        timer += Time.deltaTime;

        desired = (targetPosition - transform.position).normalized * maxSpeed;
        steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);
        velocity += steer * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    void RandomizePosition() {
        Debug.Log("adadasda");
        float x = Random.Range(-5, 5);
        float y = Random.Range(-5, 5);
        targetPosition = new Vector3(x, y, 0);
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(targetPosition, 1);
    }
}
