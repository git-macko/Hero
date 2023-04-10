using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float alphaLevel = 1f;
    [SerializeField] public int enemyHP = 4;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    //Take Damage
    public void TakeDamage(int damage)
    {
        //Damage Effect
        alphaLevel -= 0.1f;
        GetComponent<SpriteRenderer>().color = new Color (1,1,1, alphaLevel);

        //Damage
        enemyHP -= damage;
        if(enemyHP <= 0)
        {
           
            Destroy(gameObject);
            EnemyDestroyedScript.detroyCount++;
            EnemySpawnerBehavior.enemySpawned--;
        }
    }
}
