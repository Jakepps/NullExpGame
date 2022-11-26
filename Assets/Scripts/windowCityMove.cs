using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowCityMove : MonoBehaviour
{
    public GameObject camera;
    public float speed = 0.01f;
    public bool isRandomOffset = false;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(-speed, 0, 0);
        if (camera.transform.position.x - transform.position.x > 13.4f) {
            if (!isRandomOffset) {
                transform.position = new Vector3(transform.position.x + 29.99f, transform.position.y, transform.position.z);
            } else {
                transform.position = new Vector3(transform.position.x + 29.99f + Random.Range(30*10,30*20), transform.position.y, transform.position.z);
            }
            
        }
    }
}
