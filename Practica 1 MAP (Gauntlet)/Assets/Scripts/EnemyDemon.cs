using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDemon : MonoBehaviour
{
    float attackRate = 1.5f;
    float attackTimer = 0f;
    [SerializeField] int health = 10;
    [SerializeField] float speed = 3;

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
        player = GameManager.Instance.player;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            
            if (direction.magnitude > 3.0f)
            {
                Vector2 newPos = Vector2.MoveTowards(rb.position, player.transform.position, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
            }
            else{
                if (attackTimer <= 0f)
                {
                    Debug.Log("EnemyDemon Shoot()");
                    GetComponentInChildren<DemonGun>().Shoot(direction);
                    attackTimer = attackRate;
                }
                attackTimer -= Time.fixedDeltaTime;
            }
            // UpdateAnimation(direction);
        }
    }

    void UpdateAnimation(Vector2 dir)
    {
        animator.SetFloat("x", dir.x);
        animator.SetFloat("y", dir.y);
    }
}