using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float attackRate = 1.5f;
    [SerializeField] int health = 10;

    GameManager gameManager;
    GameObject player; //reference to player
    Rigidbody2D rb;

    public int getHealth() { return health; }
    public void setHealth(int health_) { health = health_; }
    public void Harm(int damage) {
        health -= damage;
        if (health <= 0) { Destroy(gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = gameManager.Player; //GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, player.transform.position, 2 * /*speed*/Time.deltaTime);
            rb.MovePosition(newPos);
            Debug.Log("following player: " + player.transform.position);
        }
    }
}