using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Colliders[] ColScripts;

    [SerializeField]
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            
            TrySpawnEnemy(enemy, 1);

        }
        //poner que si est� fuera de la c�mara o de cierto rango, no haya spawn.
        /*usar los m�todos ya creados para spawnear enemigos, por rachas de n enemigos random entre 1 y 5 con m segundos entre enemigo
        y � segundos entre rachas, siendo n,m,r Reales Random acotados a sus correspondientes l�mites.*/
    }

    void TrySpawnEnemy(GameObject enemy,int lvl)
    {
        Vector3 pos = FindSpawnPlace();
        Debug.Log(pos);
        if (pos != Vector3.zero)
        {
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }



    //busca lugar vac�o para spawn de enemigo
    Vector3 FindSpawnPlace()
    {
        int i = 0;

        bool PlaceFound = false;
        //busca huecos vac�os alrededor
        // hacer que sea random el orden de b�squeda (con arrays y eso)
        while (i < ColScripts.Length &&  !PlaceFound) 
        {
            PlaceFound = ColScripts[i].ComprobarColision();
            i++;
        }
        if (PlaceFound)
        {
            i--;
            return ColScripts[i].gameObject.transform.position;
        }
        else    return Vector3.zero; 
        
    }
    
}
