using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private int health;
    [Range(1, 10)]
    public float chaseSpeed = 3f;

    void Awake()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 15;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer() {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        // move enemy to player
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, chaseSpeed * Time.deltaTime);
    }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Bullet")) {
    //         TakeDamage(5);
    //         // ilangin bullet
    //         Destroy(other.gameObject);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")) {
            TakeDamage(5);
            other.gameObject.SetActive(false);
            Debug.Log("Enemy damaged");
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        
        if(health <= 0) {
            health = 0;
            Die();
        }
    }

    private void Die()  {
        gameObject.SetActive(false);
    }
}
