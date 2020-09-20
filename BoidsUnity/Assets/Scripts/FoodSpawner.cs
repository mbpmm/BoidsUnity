using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public int maxX = 19;
    public int maxZ = 38;
    public float timer;
    public float newSpawnTime;
    public GameObject foodGO;
    public GameObject container;
    // Start is called before the first frame update
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > newSpawnTime)
        {
            CreateFood();
            timer = 0;
        }
    }

    public GameObject CreateFood()
    {
        Vector3 randompos = new Vector3(Random.Range(-maxX, maxX), this.transform.position.y, Random.Range(-maxZ, maxZ));
        GameObject b = Instantiate(foodGO, randompos, Quaternion.identity);
        b.transform.SetParent(container.transform);
        BoidsManager.Get().foodsGO.Add(b);
        return b;
    }
}
