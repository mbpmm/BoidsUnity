using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatSteerBehaviour : SteerBehaviour
{
    public float threatRadius;
    public float maxSpeed;

    public override Vector3 GetForce(List<Boid> boids, Boid actualBoid, List<GameObject> foods, List<GameObject> threats)
    {
        Vector3 desiredVelocity = Vector3.zero;

        for (int i = 0; i < threats.Count; i++)
        {
            Vector3 diff = actualBoid.transform.position - threats[i].transform.position;
            float dist = Vector3.Distance(actualBoid.transform.position, threats[i].transform.position);

            if (dist < threatRadius)
            {
                Vector3 desiredPosition = threats[i].transform.position - actualBoid.transform.position;

                desiredVelocity = (desiredPosition.normalized * maxSpeed) - actualBoid.velocity;

                return desiredVelocity * -1.0f;
            }
        }
        return Vector3.zero;
    }
}
