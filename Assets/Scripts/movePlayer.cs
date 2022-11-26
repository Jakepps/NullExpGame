using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
  public Vector2 speed = new Vector2(50, 50);
  public GameObject camera;


  void Start() {
  }
  void Update()
  {
    int inputX, inputY;

    if (Input.GetKey(KeyCode.A))
        inputX = -1;
    else if (Input.GetKey(KeyCode.D))
        inputX = 1;
    else 
        inputX = 0;

    if (Input.GetKey(KeyCode.S))
        inputY = -1;
    else if (Input.GetKey(KeyCode.W))
        inputY = 1;
    else 
        inputY = 0;


    gameObject.GetComponent<Rigidbody2D>().velocity =new Vector2(
        speed.x * inputX,
        speed.y * inputY);
 

    
    Vector3 newPos = transform.position;

    if (camera.transform.position.x+7.7f < newPos.x) {
        newPos.x = camera.transform.position.x+7.7f;
    } else if (camera.transform.position.x-7.7f > newPos.x) {
        newPos.x = camera.transform.position.x-7.7f;
    }
    if (camera.transform.position.y+4.4f < newPos.y) {
        newPos.y = camera.transform.position.y+4.4f;
    } else if (camera.transform.position.y-4.4f > newPos.y) {
        newPos.y = camera.transform.position.y-4.4f;
    }
    transform.position = newPos;

  }

    void OnCollision2D(Collision2D collision)
    {   
    }
}
