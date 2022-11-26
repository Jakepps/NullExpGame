using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float health = 100;

    float attackColdDown = 0.5f;

    // Attack others players by radius 10
    void Attack()
    {
        bool flipX = gameObject.GetComponentInChildren<SpriteRenderer>().flipX;

        Debug.Log("Attack");
        gameObject.GetComponentInChildren<Animator>().Play("Punch", 0, 0.5f);
        // find all enemy Collider2D in radius 2 with offset 2
        // Instantiate(
        //     GameObject.FindGameObjectWithTag("Circle"),
        //     transform.position + new Vector3((flipX ? -1 : 1) * 1.5f, 1, 0),
        //     Quaternion.identity
        // );
        if (attackColdDown < 0.1)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position + new Vector3((flipX ? -1 : 1) * 1.75f, 0, 0), 1f);

            Debug.Log(hitColliders.Length);
            foreach (var hitCollider in hitColliders)
            {
                // if enemy is found
                if (hitCollider.gameObject.tag == "Enemy")
                {
                    attackColdDown = 0.5f;
                    Debug.Log("Enemy found");
                    // get enemy script
                    Enemy enemy = hitCollider.gameObject.GetComponent<Enemy>();
                    // attack enemy
                    gameObject.GetComponentInChildren<Rigidbody2D>().velocity = Vector2.zero;
                    enemy.TakeDamage(10);
                    enemy.TakeImpulse(new Vector2((flipX ? -1 : 1) * 1000f, 0));
                }
            }
        }




    }

    //take damage
    public void TakeDamage(int damage)
    {
        gameObject.GetComponentInChildren<Animator>().Play("getDamage", 0, 0.2f);
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // take impulse 
    public void TakeImpulse(Vector2 impulse)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(impulse);
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
        if (attackColdDown > 0)
        {
            attackColdDown -= Time.deltaTime;
        }

        health += Time.deltaTime;

        // Attack on press left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
}
