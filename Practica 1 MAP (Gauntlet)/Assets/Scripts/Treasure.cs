using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null) //ducktyping
        {
            GameManager.Instance.TreasureCollected();
            Destroy(gameObject);


        }
    }
}
