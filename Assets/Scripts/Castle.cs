using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {

    private int health;
    public int Health
    {
        get
        {
            return health;
        }

        private set
        {
            health = value;
        }
    }
    public int maxHealth = 100;

    private int shield;
    public int Shield
    {
        get
        {
            return shield;
        }

        private set
        {
            shield = value;
        }
    }
    public int maxShield = 100;

    //amount of shield that recovered for recoveryCooldown
    public float shieldRecovery = 1f;

    //TODO delay before starting shield recovery 
    public float delayBeforeRecovery = 1f;
    private bool recoveryAllowed = false;

    private float recoveryCooldown = 0f;

    public static Castle Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    //destroy enemy when it enters and take damage from enemy
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            TakeDamage(enemy.damage);
            enemy.Destroy();
        }
    }

    private void Start()
    {
        health = maxHealth;
        shield = maxShield;
    }

    private void Update()
    {
        if (recoveryAllowed)
        {
            StartCoroutine(StartRecovery(shieldRecovery));
        }
        else if(Shield < maxShield && !recoveryAllowed)
        {
            StartCoroutine(WaitBeforeRecovery(delayBeforeRecovery));
        }
    }

    private IEnumerator StartRecovery(float recoveryValue)
    {
        if (Shield >= maxShield)
        {
            recoveryAllowed = false;
            recoveryCooldown = 0f;
            yield return null;
        }
        else
        {
            if (recoveryCooldown <= 0f)
            {
                Shield += 1;
                recoveryCooldown = 1 / recoveryValue;
            }
            else
                recoveryCooldown -= Time.deltaTime;
        }
    }
    private IEnumerator WaitBeforeRecovery(float delay)
    {
        yield return new WaitForSeconds(delay);
        recoveryAllowed = true;
    }

    public void TakeDamage(int damage)
    {
        if (Shield - damage >= 0)
        {
            Shield -= damage;
        }
        else
        {
            Health -= damage - Shield;
            Shield = 0;
        }

        if (Health <= 0)
        {
            Health = 0;
            GameMaster.Instance.GameOver();
        }
    }

}
