using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveTrigger : MonoBehaviour
{
    public bool timeToMove = false;


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
