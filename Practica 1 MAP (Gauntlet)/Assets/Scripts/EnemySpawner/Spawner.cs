
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Colliders[] ColScripts;

    [SerializeField]
    private GameObject enemy;
    [SerializeField] float enemyRate;
    float nextEnemySpawn = 0;
    [SerializeField] public bool onCollider = false;
    [SerializeField] private int[] enemyRndAmount;
    struct AvilableSpawnPlaces 
    {

        public Vector3[] pos;
        public int tam;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        if (onCollider && Time.time > nextEnemySpawn && enemy != null)
        {
            
            TrySpawnEnemy(enemy, enemyRndAmount[Random.Range(0,10)]);
            nextEnemySpawn = Time.time + enemyRate*Random.Range(0.9f,1.1f);
        }
    }
    

    //poner que si está fuera de la cámara o de cierto rango, no haya spawn.



    //solo se puede llamar una vez por frame
    private void TrySpawnEnemy(GameObject enemy, int amount)
    {

        FindSpawnPlaces(out AvilableSpawnPlaces posPosibleSpawn);

        if (posPosibleSpawn.tam < amount)
        {
            amount = posPosibleSpawn.tam;
        }

        RandomizeVector3Array(posPosibleSpawn.pos, posPosibleSpawn.tam);

        for (int i = 0; i < amount; i++)
        {

            Instantiate(enemy, posPosibleSpawn.pos[i], Quaternion.identity);

        }

    }

    //Randomiza array y NO lo hace lo más pequeño posible (aunque se podría cambiar easy)
    private void RandomizeVector3Array(Vector3[] array,int tam)
    {
        int vueltas = 0;
        Vector3[] tempArray = new Vector3[tam];

        for (int i = 0; i < tempArray.Length; i++) 
        {
            int j = Random.Range(0, tam);

            tempArray[i] = array[j];

            tam--;

            for (int k = j; k < tam; k++) 
            {
                array[k] = array[k + 1];
            }
            
            vueltas++;
        }
        

        for (int i = 0;i < tempArray.Length; i++)
        {
            array[i] = tempArray[i];
            
        }
        
    }

    //busca lugar vacío para spawn de enemigo
    private void FindSpawnPlaces(out AvilableSpawnPlaces places)
    {
        int i = 0;
        
        

        places.pos = new Vector3[ColScripts.Length];
        places.tam = 0;

        
        //busca huecos vacíos alrededor
        // hacer que sea random el orden de búsqueda (con arrays y eso)
        for (i=0; i < ColScripts.Length;i++) 
        {
            bool PlaceFound = ColScripts[i].ComprobarColision();
            if (PlaceFound)
            {
                places.pos[places.tam] = ColScripts[i].gameObject.transform.position;
                places.tam++;
            }
        }        
    }
 
    

}
