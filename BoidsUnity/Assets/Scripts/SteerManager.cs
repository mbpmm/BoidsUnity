using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerManager : MonoBehaviour
{
    public List<SteerBehaviour> steerBehaviours;

    public void Start()
    {
    }

    public Vector3 GetSteeringBehavioursValues(List<Boid> boids, Boid actualBoid, List<GameObject> foods, List<GameObject> threats)
    {
        Vector3 toReturn = Vector3.zero;

        foreach (SteerBehaviour sb in steerBehaviours)
        {
            toReturn += sb.GetForce(boids, actualBoid, foods,threats);
        }

        return toReturn;
    }
}
