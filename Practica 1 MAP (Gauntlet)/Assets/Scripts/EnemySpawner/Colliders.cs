using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    private int tocandome;
    // Start is called before the first frame update
    void Start()
    {
        tocandome = 0;
    }

    private void OnTriggerEnter2D()
    {
        tocandome++;
        //Debug.Log(gameObject+"entrado" + tocandome);
    }
    private void OnTriggerExit2D()
    {
        tocandome--;
        //Debug.Log(gameObject+"salido"+tocandome);
    }
    // Update is called once per frame


    //devuelve true si no hay enemigos en este hueco
    public bool ComprobarColision()
    {
        Debug.Log(gameObject +" "+ (tocandome <= 0));
        return tocandome <= 0;
        
    }
    
    void Update()
    {
        
    }
}
