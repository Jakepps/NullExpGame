using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject player;

    public List<float> stopPos; 
    private int nowStop = 0;

    public bool isCameraMove = false;

    private Vector3 newPos;
    void Start()
    {
        newPos = transform.position;
    }

    void Update()
    {
        Vector3 delta =  (newPos-transform.position);
        transform.position += new Vector3(delta.x*0.05f, delta.y*0.05f, delta.z);

        if (isCameraMove)  {
            if (player.transform.position.x - transform.position.x > 5) {
                newPos = new Vector3(player.transform.position.x - 5, transform.position.y, -10);  
            }
            if (transform.position.x > stopPos[nowStop]) {
                transform.position = new Vector3(stopPos[nowStop], transform.position.y, -10);
                nowStop++;
                isCameraMove = false;
            }
        } 
    }
}
