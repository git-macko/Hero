using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehavior : MonoBehaviour
{
    //Movement 
    
    bool controlSwitch = false;
    
    private Rigidbody2D rb2d;
    

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed = 0.1f;
    
    //Bullets
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float bulletSpeed = 40f;
    private float cooldown = .2f;
    private float nextFire = 0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Hero's Controller Mode Switch
        if (Input.GetKeyDown(KeyCode.M))
        {
            controlSwitch = !controlSwitch;
        }
        SwitchController();
        EggBullets();
        
        
    }

    private void SwitchController()
    {
       if(controlSwitch == false)
       {
            HeroModeScript.heroMode = "Mouse";
            HeroMouseMovement();
       }
       else
       {
            HeroModeScript.heroMode = "Keyboard";
            HeroKeysMovement();
       }
    }
    //Hero Destroys
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            EnemyDestroyedScript.detroyCount++;
            TouchedEnemiesScript.touchCount++;
            Destroy(collision.gameObject);
            EnemySpawnerBehavior.enemySpawned--;
        }
    }


    //Hero Movements
    private void HeroKeysMovement()
    {
        // Change Speed
        if (Input.GetKey(KeyCode.W)) {
            speed += 0.2f;
        } else if (Input.GetKey(KeyCode.S)) {
            if (speed - 2 < 0 ) {
                speed = 0f;
            } else {
                speed -= 0.2f;
            }
        }

        // Change direction
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,0,rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0,0,-1 * rotationSpeed);
        }
        rb2d.velocity = transform.up * speed;
    }
    private void HeroMouseMovement()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

        // Change direction
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,0,rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0,0,-1 * rotationSpeed);
        }
        rb2d.velocity = transform.up * speed;
    }

    //Hero's Egg Bullets
    private void EggBullets()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D re = bullet.GetComponent<Rigidbody2D>();
            re.velocity = firePoint.up * bulletSpeed;
            nextFire = Time.time + cooldown;
        }
    }
}

