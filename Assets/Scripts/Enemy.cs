using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Utilities;

public class Enemy : MonoBehaviour {

    public ElementTypes type;
    public float speed = 1f;
    public int maxHealth = 100;
    private int health = 100;
    public int damage = 10;
    public int reward = 10;
    
    //if resist count > 100 damage became heal (125 resist will heal for 25% of damage)
    public Resist[] resists;

    public Image healthbar;


    private void Start()
    {
        health = maxHealth;
    }
    void Update ()
    {
        //move enemy down with some speed
        transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);
    }

    public void TakeDamage(int damage, ElementTypes damageType)
    {
        foreach(Resist resist in resists)
        {
            if (resist.resistType == damageType)
            {
                health -= (int)(damage * ((100 - resist.resistCount) / 100f));
                //Debug.Log("Health = " + health);

                //change healthbar
                healthbar.fillAmount = (float)health / maxHealth;

                break;
            }
        }

        if (health <= 0)
        {
            //give player a money of enemy type for killing the enemy
            PlayerStats.AddMoney(reward);

            Destroy();
        }
    }

    public void Destroy()
    {
        //
        //stop enemy
        speed *= 0.5f;

        //hide healthbar
        gameObject.GetComponentInChildren<Canvas>().enabled = false;

        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("destroy");
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
