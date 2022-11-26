using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveTrigger : MonoBehaviour
{
    public bool timeToMove = false;

    public Vector2 newPosition =new  Vector2(15, 0);
    public GameObject camera;

    void Update(){
        if (timeToMove) {

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!timeToMove) {
            timeToMove = !timeToMove;


        }
    }
}
