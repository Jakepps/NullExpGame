using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
  public Vector2 speed = new Vector2(50, 50);

  private Vector2 movement;

  public GameObject camera;

    
  private Vector3 lastMove;


  void Update()
  {
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    movement = new Vector2(
      speed.x * inputX,
      speed.y * inputY);

    
    Vector2 newPos = transform.position + new Vector3(movement.x, movement.y, 0);

    transform.position = newPos;
  }
}
