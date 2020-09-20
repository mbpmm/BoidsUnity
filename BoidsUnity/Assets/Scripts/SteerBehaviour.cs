using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SteerBehaviour : MonoBehaviour
{
    public bool isActive;
    [Range(0, 20)]
    public float weight;
    public Slider weightSlider;
    public abstract Vector3 GetForce(List<Boid> boids, Boid actualBoid, List<GameObject> foods, List<GameObject> threats);

    public void Awake()
    {
        weightSlider.value = weight;
    }
    public void Update()
    {
        weight = weightSlider.value;
    }
}
