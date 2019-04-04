using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : BaseEnemy {

    public float fireRate;
    public float velocity;
    
    public Rigidbody2D projectile;
    public Transform projectileSpawnPoint;

    public bool isFacingRight;

    float fireDelay;

	void Start () {
        Startup();
	}

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (Time.time > fireDelay + fireRate)
            {
                Invoke("Fire", 0.5f);
               fireDelay = Time.time;
            }
        }
    }

    void Fire()
    {
        Debug.Log("Fired");
        
        if (projectileSpawnPoint && projectile)
        {
            Rigidbody2D temp = Instantiate(projectile, projectileSpawnPoint.position,
                projectileSpawnPoint.rotation);

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), 
                temp.GetComponent<Collider2D>(), true);
            
            if (isFacingRight)
            {
                temp.transform.Rotate(0, 180, 0);
                temp.AddForce(projectileSpawnPoint.right * velocity, ForceMode2D.Impulse);
            }
            else
                temp.AddForce(-projectileSpawnPoint.right * velocity, ForceMode2D.Impulse);
        }
    }

    void Startup()
    {
        if (fireRate <= 0)
        {
            fireRate = 2.0f;
        }

        if (!projectile)
        {
            Debug.LogError("Projectile not found on " + name);
        }

        if (!projectileSpawnPoint)
        {
            Debug.LogError("ProjectileSpawnPoint not found on " + name);
        }

        if (velocity <= 0)
        {
            velocity = 5.0f;
        }
    }
}
