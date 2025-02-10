using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFood : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            GameManager.Instance.DebugFoodCollected();
            Destroy(gameObject);

        }
    }
}
