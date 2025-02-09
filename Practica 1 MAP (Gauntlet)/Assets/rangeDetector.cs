using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeDetector : MonoBehaviour
{
    [SerializeField] Spawner spawnerscript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            spawnerscript.onCollider = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            spawnerscript.onCollider = false;
        }

    }
}
