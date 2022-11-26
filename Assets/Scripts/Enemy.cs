using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health = 100;

    // Attack others players by radius 10
    void Attack()
    {
        // find all enemy in radius 10 with offset 10
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 10);

        foreach (var hitCollider in hitColliders)
        {
            // if enemy is found
            if (hitCollider.gameObject.tag == "Player")
            {
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


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
