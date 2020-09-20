using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 position;
    public Vector3 velocity;
    public Vector3 cero;
    public float angle;
    public float speed;
    public float radius;
    public float perceptionRadius;
    public float separationRadius;
    public float maxSpeed;
    public bool hasCollided;
    public int waypoint;

    public int foodEaten;
    private int maxFood = 5;
    public GameObject threat;
    // Start is called before the first frame update
    void Start()
    {
        
        cero = Vector3.zero;
        angle = UnityEngine.Random.Range(1,360);
        speed = UnityEngine.Random.Range(5, 8);
        radius = 2;
        velocity = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), UnityEngine.Random.Range(-1, 1)) * speed;
        perceptionRadius = 15;
        separationRadius = 8;
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
        maxSpeed = 15;
        
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pared")
        {
            hasCollided = !hasCollided;
        }

        if (other.gameObject.tag == "food")
        {
            foodEaten++;
            BoidsManager.Get().foodsGO.Remove(other.gameObject);
            Destroy(other.gameObject);
            if (foodEaten>=maxFood)
            {
                BoidsManager.Get().boids.Remove(this);
                BoidsManager.Get().boidsGO.Remove(gameObject);
                Destroy(gameObject);
                GameObject t = Instantiate(threat, transform.position, Quaternion.identity);
                BoidsManager.Get().threatsGO.Add(t);
            }
        }
    }

    public Vector3 LimitVelocity(Vector3 v, float limit)
    {
        if (v.magnitude > limit)
        {
            v = v / v.magnitude * limit;
        }
        return v;
    }

    public Vector3 LimitRotation(Vector3 v, float maxAngle, float maxSpeed)
    {
        return Vector3.RotateTowards(velocity, v, maxAngle * Mathf.Deg2Rad, maxSpeed);
    }

}
