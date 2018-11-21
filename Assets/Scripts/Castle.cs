using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {

    public int health = 100;

    public static Castle Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one Castle in the game!");
            return;
        }

        Instance = this;
    }

    //destroy enemy when it enters and take damage from enemy
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            //enemy.DealDamage();
            TakeDamage(enemy.damage);
            enemy.Destroy();
            //******************
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //game over
        }
    }

}
