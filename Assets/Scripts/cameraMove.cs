using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject player;

    public GameObject camera;
    public List<float> stopPos; 
    private int nowStop = 0;

    public bool isCameraMove = true;

    private Vector3 newPos;
    void Start()
    {
        newPos = transform.position;
    }

    void Update()
    {
        if (isCameraMove)  {
            if (player.transform.position.x - camera.transform.position.x > 0) {
                print(new Vector3(player.transform.position.x - 0, camera.transform.position.y, -10));
                camera.transform.position = new Vector3(player.transform.position.x - 0, camera.transform.position.y, -10);  
            }
            if (camera.transform.position.x > stopPos[nowStop]) {
                print(3);
                camera.transform.position = new Vector3(stopPos[nowStop], camera.transform.position.y, -10);
                nowStop++;
                isCameraMove = true;
            }
        } 
    }
}
