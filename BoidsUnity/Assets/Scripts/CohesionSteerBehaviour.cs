﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionSteerBehaviour : SteerBehaviour
{
    public float cohesionRadius;
    public float cohesionMaxSpeed;
    public override Vector3 GetForce(List<Boid> boids, Boid actualBoid, List<GameObject> foods, List<GameObject> threats)
    {
        Vector3 desired_velocity = new Vector3(0, 0, 0);
        int countNeighbors = 0;

        foreach (Boid b in boids)
        {
            if (actualBoid == b)
                continue;

            Vector3 diff = actualBoid.transform.position - b.transform.position;
            float dist = diff.magnitude;

            if (dist < cohesionRadius)
            {
                countNeighbors++;
                desired_velocity += b.transform.position;
            }
        }

        if (countNeighbors > 0)
        {
            desired_velocity /= countNeighbors;
            return desired_velocity /*- actualBoid.velocity*/;
        }
        else
        {
            return Vector3.zero;
        }
    }
}