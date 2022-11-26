using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowCityMove : MonoBehaviour
{
    public GameObject camera;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(-0.01f, 0, 0);
        if (camera.transform.position.x - transform.position.x > 13.4f) {
            transform.position = new Vector3(transform.position.x + 29.99f, transform.position.y, transform.position.z);
        }
    }
}
