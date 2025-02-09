using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    float attackRate = 1.5f;
    [SerializeField] int health = 10;
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] float cooldown;
    bool attacking;
    bool collision2;

    GameManager gameManager;
    GameObject player; // Reference to player
    Rigidbody2D rb;

    private Animator animator;
    private SpriteRenderer sr;

    public int getHealth() { return health; }
    public void setHealth(int health_) { health = health_; }

    public void Harm(int damage)
    {
        health -= damage;
        Color c = sr.color;
        c.a /= 3;  // Reduce opacity by a third
        sr.color = c;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = gameManager.player;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null && !collision2) // Only move if there's no collision
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            Vector2 newPos = Vector2.MoveTowards(rb.position, player.transform.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

            UpdateAnimation(direction);
        }
        else
        {
            // Stop Rigidbody when colliding
            rb.velocity = Vector2.zero;
        }
    }

    void UpdateAnimation(Vector2 dir)
    {
        animator.SetFloat("x", dir.x);
        animator.SetFloat("y", dir.y);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision2 = true;
            if (!attacking)
            {
                attacking = true;
                StartCoroutine(Attack(collision.gameObject.GetComponent<Health>()));
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        collision2 = false;
    }

    private IEnumerator Attack(Health health)
    {
        while (collision2) // Keep attacking while in collision
        {
            health.Harm(damage);
            yield return new WaitForSeconds(cooldown);
        }
        attacking = false;
    }
}

