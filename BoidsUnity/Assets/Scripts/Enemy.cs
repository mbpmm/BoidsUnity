using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {

        cero = Vector3.zero;
        angle = UnityEngine.Random.Range(1, 360);
        speed = UnityEngine.Random.Range(5, 8);
        radius = 2;
        velocity = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), UnityEngine.Random.Range(-1, 1)) * speed;
        perceptionRadius = 15;
        separationRadius = 8;
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
        maxSpeed = 15;

    }

    private void Update()
    {
        if (hasCollided)
        {
            transform.position += (velocity * -1f) * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity * -1f));
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pared")
        {
            hasCollided = !hasCollided;
        }
    }
}
