using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekSteerBehaviour : SteerBehaviour
{
    public GameObject waypointsParent;
    public GameObject[] waypoints;
    public float waypointDistance;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = new GameObject[waypointsParent.transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointsParent.transform.GetChild(i).gameObject;
        }
    }

    public override Vector3 GetForce(List<Boid> boids, Boid actualBoid, List<GameObject> foods, List<GameObject> threats)
    {
        if (waypoints.Length > 0)
        {
            Vector3 waypointForce = Vector3.zero;

            Vector3 desiredPosition = waypoints[actualBoid.waypoint].transform.position - actualBoid.transform.position;

            Vector3 desiredVelocity = desiredPosition - actualBoid.velocity;

            if (Vector3.Distance(actualBoid.transform.position, waypoints[actualBoid.waypoint].transform.position) < waypointDistance)
            {
                actualBoid.waypoint++;
                if (actualBoid.waypoint >= waypoints.Length)
                {
                    actualBoid.waypoint = 0;
                }
            }
            
            return desiredVelocity;
        }
        else
        {
            return Vector3.zero;
        }
    }
}