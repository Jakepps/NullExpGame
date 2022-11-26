using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health = 100;

    bool flipX = false;

    // Attack others players by radius 10
    void Attack()
    {
        // find all enemy in radius 10 with offset 10

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2);

        foreach (var hitCollider in hitColliders)
        {
            // if enemy is found
            if (hitCollider.gameObject.tag == "Player")
            {
                gameObject.GetComponentInChildren<Animator>().Play("Punch", 0, 0.5f);
                Debug.Log("Player found");
                // get enemy script
                Player player = hitCollider.gameObject.GetComponent<Player>();
                // attack enemy
                player.TakeDamage(10);
                player.TakeImpulse(new Vector2((flipX ? -1 : 1) * 1000f, 0));
            }
        }
    }

    // coroutine for attack
    IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSecondsRealtime(Random.Range(0.3f, 1f));
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



    //take damage
    public void TakeImpulse(Vector2 vector)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(vector);
    }

    //die
    void Die()
    {
        Destroy(gameObject);
    }


    void Start()
    {
        flipX = gameObject.GetComponentInChildren<SpriteRenderer>().flipX;
        StartCoroutine(AttackCoroutine());
    }

    void FixedUpdate()
    {
        // find player
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        // float Speed = Random.Range(0.1F, 1.0F);

        // // move towards player
        // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed / 5);

        // Vector3 direction_to_player = (player.transform.position - transform.position).normalized;
        // GetComponent<Rigidbody2D>().AddForce(direction_to_player * Speed);
    }

    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float Speed = 2;

        // move towards player
        Vector2 target = player.transform.position;
        // Debug.Log(Vector2.Distance(transform.position, target));
        // Debug.Log(Vector2.Distance(transform.position, target) > 2f);
        if (Mathf.Abs(target.x - transform.position.x) > 2f)
        {
            target = new Vector2(target.x, transform.position.y);
        }



        gameObject.GetComponentInChildren<SpriteRenderer>().flipX = target.x < transform.position.x;

        if (Vector2.Distance(transform.position, target) < 15)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * Speed);
        }

    }
}
