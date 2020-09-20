using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationSteerBehaviour : SteerBehaviour
{
    public float separationRadius;
    public float separationMaxSpeed;
    public override Vector3 GetForce(List<Boid> boids, Boid actualBoid, List<GameObject> foods, List<GameObject> threats) 
    {
        Vector3 desired_velocity = Vector3.zero;
        int countNeighbour = 0;
        foreach (Boid b in boids)
        {
            if (actualBoid == b)
                continue;

            Vector3 diff = actualBoid.transform.position - b.transform.position;
            float dist = Vector3.Distance(actualBoid.transform.position, b.transform.position);

            if (dist < separationRadius)
            {
                countNeighbour++;
                //dist /= separationRadius;
                //desired_velocity += diff.normalized * separationMaxSpeed / dist;
                desired_velocity = desired_velocity + Vector3.Normalize(diff) / Mathf.Pow(dist, 2);
            }
            
        }

        if (countNeighbour > 0)
        {
            //desired_velocity /= countNeighbour;
            
            return desired_velocity/* - actualBoid.velocity*/;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
