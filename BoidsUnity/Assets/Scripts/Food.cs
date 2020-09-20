using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Update()
    {
        gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

}
