using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDemon : MonoBehaviour
{
    float attackRate = 1.5f;
    float attackTimer = 0f;
    [SerializeField] int damage;
    [SerializeField] int health = 10;
    [SerializeField] float speed = 3;
    [SerializeField] float cooldown;
    bool attacking;
    bool collision3;

    GameManager gameManager;
    GameObject player; //reference to player
    Rigidbody2D rb;

    private Animator animator;
    private SpriteRenderer sr;

    public int getHealth() { return health; }
    public void setHealth(int health_) { health = health_; }
    public void Harm(int damage)
    {
        health -= damage;
        Color c = sr.color;
        c.a /= 3;  // Divide la opacidad por 3
        sr.color = c;
        if (health <= 0) { Destroy(gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = GameManager.Instance.player;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null && !collision3)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer > 3.0f) // Si está lejos, se mueve
            {
                Vector2 newPos = Vector2.MoveTowards(rb.position, player.transform.position, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
            }
            else // Si está en rango de ataque, deja de moverse y dispara
            {
                rb.velocity = Vector2.zero; // Detener el movimiento

                if (attackTimer <= 0f) // Dispara solo si el cooldown terminó
                {
                    Debug.Log("EnemyDemon Shoot()");
                    GetComponentInChildren<DemonGun>().Shoot(direction, transform.position);
                    attackTimer = attackRate;
                }
                attackTimer -= Time.fixedDeltaTime;
            }

            // Actualizar animación
            UpdateAnimation(direction);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision3 = true;
            if (!attacking)
            {
                attacking = true;
                StartCoroutine(Attack(collision.gameObject.GetComponent<Health>()));
            }
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        collision3 = false;
    }
    void UpdateAnimation(Vector2 dir)
    {
        animator.SetFloat("x", dir.x);
        animator.SetFloat("y", dir.y);
    }

    private IEnumerator Attack(Health health)
    {
        while (collision3) // Keep attacking while in collision
        {
            health.Harm(damage);
            yield return new WaitForSeconds(cooldown);
        }
        attacking = false;
    }
}