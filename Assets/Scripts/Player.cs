using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    int health = 100;

    // Attack others players by radius 10
    void Attack()
    {
        Debug.Log("Attack");
        // find all enemy Collider2D in radius 2 with offset 2
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(2, 0, 0), 2);
        Debug.Log(hitColliders.Length);
        foreach (var hitCollider in hitColliders)
        {
            // if enemy is found
            if (hitCollider.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy found");
                // get enemy script
                Enemy enemy = hitCollider.gameObject.GetComponent<Enemy>();
                // attack enemy
                enemy.TakeDamage(10);
            }
        }



    }

    //take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    //die
    void Die()
    {
        Destroy(gameObject);
    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Attack on press left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
}
