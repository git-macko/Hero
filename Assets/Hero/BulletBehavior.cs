using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    void Update()
    {
        
        //Bullet gets destroy when off camera
        if(!gameObject.GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
    void OnBecameInvisible() {
         Destroy(gameObject);
     }
    // Destroy target when hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehavior enemy = collision.GetComponent<EnemyBehavior>();

        if(enemy != null)
        {
            enemy.TakeDamage(1);
            if(collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
        
        
        
    }
}
