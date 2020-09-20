using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsManager : MonobehaviourSingleton<BoidsManager>
{
    public List<Boid> boids;
    public List<GameObject> boidsGO;
    public List<GameObject> foodsGO;
    public List<GameObject> threatsGO;
    public SteerBehaviour[] steerBehaviours;
    public Vector3[] steersUsed;
    public GameObject boidPrefab;
    public GameObject threatPrefab;
    public float maxSpeed;
    public float maxRot;

    public GameObject target;
    public GameObject boidContainer;
    public GameObject threatContainer;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            CreateBoid();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            CreateThreat();
        }

        if (boids.Count>0)
        {
            for (int i = 0; i < boids.Count; i++)
            {
                for (int c = 0; c < steerBehaviours.Length; c++)
                {
                    if (steerBehaviours[c].isActive)
                    {
                        steersUsed[c] = steerBehaviours[c].GetForce(boids, boids[i],foodsGO,threatsGO);
                    }
                }

                for (int j = 0; j < steerBehaviours.Length; j++)
                {
                    if (steerBehaviours[j].isActive)
                    {
                        boids[i].velocity += steersUsed[j] * steerBehaviours[j].weight*Time.deltaTime;
                        boids[i].velocity = boids[i].LimitVelocity(boids[i].velocity, maxSpeed);
                        boids[i].velocity = boids[i].LimitRotation(boids[i].velocity, maxRot,maxSpeed);
                    }
                }

                if (boids[i].hasCollided)
                {
                    boids[i].transform.position += (boids[i].velocity * -1f) * Time.deltaTime;
                    boids[i].gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(boids[i].velocity * -1f));
                }
                else
                {
                    boids[i].transform.position += boids[i].velocity * Time.deltaTime;
                    boids[i].gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(boids[i].velocity));
                }
            }
        }
    }

    public void CreateBoid()
    {
        Vector3 randompos = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
        GameObject boidGO = Instantiate(boidPrefab, randompos, Quaternion.identity);
        boidGO.transform.SetParent(boidContainer.transform);
        boidsGO.Add(boidGO);
        boids.Add(boidGO.GetComponent<Boid>());
    }

    public void CreateThreat()
    {
        Vector3 randompos = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
        GameObject threatGO = Instantiate(threatPrefab, randompos, Quaternion.identity);
        threatGO.transform.SetParent(threatContainer.transform);
        threatsGO.Add(threatGO);
    }
}
