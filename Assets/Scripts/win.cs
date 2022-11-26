using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    public bool dad = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (dad) {
            Application.Quit();
        }
    }

    void OnTriggerEnter2D(Collider2D er) {
        gameObject.GetComponentInChildren<Animator>().Play("2133", 0, 1.5f);
    }
}
