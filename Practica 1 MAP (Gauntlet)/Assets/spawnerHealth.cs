using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int healthIni = 3;
    [SerializeField]
    private Sprite spriteFull1;
    [SerializeField]
    private Sprite spriteMid1;
    [SerializeField]
    private Sprite spriteLow1;
    [SerializeField]
    private Sprite spriteFull2;
    [SerializeField]
    private Sprite spriteMid2;
    [SerializeField]
    private Sprite spriteLow2;
    [SerializeField]
    private Sprite spriteFull3;
    [SerializeField]
    private Sprite spriteMid3;
    [SerializeField]
    private Sprite spriteLow3;
    [SerializeField]
    private int tipoEnemy;
   
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetHealthIni(healthIni);
    }

    // Update is called once per frame
    void Update()
    {
        if (tipoEnemy == 1)
        {
            SetSpriteEnemy1();
        }

        if (tipoEnemy == 2)
        {
            SetSpriteEnemy2();
        }

        if (tipoEnemy == 3)
        {
            SetSpriteEnemy3();
        }
    }
    private void SetHealthIni(int healthIni)
    {
        health = healthIni;
    }
    private void SetSpriteEnemy1()
    {
        if (health == 3)
        {
            spriteRenderer.sprite = spriteFull1;
        } 
        else if (health == 2)
        {
            spriteRenderer.sprite = spriteMid1;
        } 
        else if (health == 1)
        {
            spriteRenderer.sprite = spriteLow1;
        }
    }

    private void SetSpriteEnemy2()
    {
        if (health == 3)
        {
            spriteRenderer.sprite = spriteFull2;
        } 
        else if (health == 2)
        {
            spriteRenderer.sprite = spriteMid2;
        } 
        else if (health == 1)
        {
            spriteRenderer.sprite = spriteLow2;
        }
    }

    private void SetSpriteEnemy3()
    {
        if (health == 3)
        {
            spriteRenderer.sprite = spriteFull3;
        } 
        else if (health == 2)
        {
            spriteRenderer.sprite = spriteMid3;
        } 
        else if (health == 1)
        {
            spriteRenderer.sprite = spriteLow3;
        }
    }
    public void SpawnerHarm()
    {
        Debug.Log("Auch");
        health--; 
        if (health == 0) Destroy(gameObject);
    }
}
