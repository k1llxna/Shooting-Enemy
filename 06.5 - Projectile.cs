using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float lifeTime;
    public BaseEnemy enemy;

    void Start()
    {

        if (lifeTime <= 0)
        {
            // Assign a default value if one was not set
            lifeTime = 2.0f;
        }
        Destroy(gameObject, lifeTime);
    }

    void Update()   { }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(enemy.atkDmg);
        }
        Destroy(gameObject);
    }
}
