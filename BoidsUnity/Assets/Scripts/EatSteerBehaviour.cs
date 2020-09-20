using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatSteerBehaviour : SteerBehaviour
{
    public float perceptionRadius;
    public float maxSpeed;

    public override Vector3 GetForce(List<Boid> boids, Boid actualBoid, List<GameObject> foods, List<GameObject> threats)
    {
        Vector3 desiredVelocity = Vector3.zero;

        for (int i = 0; i < foods.Count; i++)
        {
            Vector3 diff = actualBoid.transform.position - foods[i].transform.position;
            float dist = Vector3.Distance(actualBoid.transform.position, foods[i].transform.position);

            if (dist < perceptionRadius)
            {
                Vector3 desiredPosition = foods[i].transform.position - actualBoid.transform.position;

                desiredVelocity = (desiredPosition.normalized * maxSpeed) - actualBoid.velocity;

                if (dist < 0.5f)
                {
                    Debug.Log("yum yum: "+ actualBoid.foodEaten);
                }
                return desiredVelocity;
            }
        }
        return Vector3.zero;
    }
}
