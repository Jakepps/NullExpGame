using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
  public Vector2 speed = new Vector2(50, 50);

  private Vector2 movement;

    
  private Vector3 lastMove;


  void Update()
  {
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    movement = new Vector2(
      speed.x * inputX,
      speed.y * inputY);


    lastMove = transform.position; 
    transform.position += new Vector3(movement.x, movement.y, 0);
  }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print(1);
        transform.position = lastMove;
        
    }
}
