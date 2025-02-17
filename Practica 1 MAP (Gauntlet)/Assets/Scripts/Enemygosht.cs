using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemygosht : MonoBehaviour
{
    float attackRate = 1.5f;
    [SerializeField] int health = 10;
    [SerializeField] float maxHealthThisEnemyType;
    [SerializeField] float speed;
    [SerializeField] int damage;

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
        changeOpacity();
        if (health <= 0) { Destroy(gameObject); }
    }

    private void changeOpacity()
    {
        Color c = sr.color;
        c.a = health / maxHealthThisEnemyType;  // opacidad = vida/vidaMaxEsteTipoDeEnemigos
        sr.color = c;

    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = gameManager.player; //GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        changeOpacity();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            Vector2 newPos = Vector2.MoveTowards(rb.position, player.transform.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

            UpdateAnimation(direction);
        }
    }

    void UpdateAnimation(Vector2 dir)
    {
        animator.SetFloat("x", dir.x);
        animator.SetFloat("y", dir.y);
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.Harm(damage);
            if (GameManager.Instance.firstHarm)
            {
                GameManager.Instance.CallTutorial("SHOOT OR AVOID GHOSTS PLAYER LOSES 9 HEALTH");
                GameManager.Instance.firstHarm = false;
            }
            Destroy(gameObject);
            
        }
        /*
        else //bugfix enemigos que traspasan muros
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            // Si el objeto contra el que choc� es est�tico o kinematic, activar isKinematic
            if (rb != null && (rb.isKinematic || collision.gameObject.isStatic))
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        */
    }

    /*private void OnCollisionExit2D(Collision2D collision) //bugfix enemigos que traspasan muros
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
    */
}