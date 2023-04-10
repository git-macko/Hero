using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] int spawnlimit = 10;
    public static int enemySpawned=0;

     // Update is called once per frame
     void Update()
     {
        
         if(enemySpawned < spawnlimit)
         {
        
            enemySpawned++;
             EnemyCountScript.enemyCount = enemySpawned;
             SpawnObject();
         }

        
     }

     private void SpawnObject()
     {
         bool objSpawned = false;
         while (!objSpawned)
         {
            //radius of spawn
             Vector3 objPosition = new Vector3(Random.Range(-150f, 150f), Random.Range(-50f, 50f), 0);
             
             //ensures new object is spawned far enough away
             if ((objPosition - transform.position).magnitude < 10)
             {
                 continue;
             }
             else
             {
                 objSpawned = true;
                 Instantiate(Enemy, objPosition, Quaternion.identity);
             }
         }
         
     }
}
