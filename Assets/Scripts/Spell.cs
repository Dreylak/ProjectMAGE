using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    public Animator animator;

    Vector2 target;

    public float speed = 1f;
    public float cooldown = 1f;
    public float damageRadius = 2f;
    public int damage = 50;
    private bool targetReached = false;

    public GameMaster.ElementTypes damageType = GameMaster.ElementTypes.Neutral;

    void Start()
    {
    }

    void FixedUpdate()
    {
        //if spell reached the target deal damage and destroy spell
        if (targetReached) return;

        if (Vector2.Distance(new Vector2(target.x, target.y),
                            new Vector2(transform.position.x, transform.position.y)) <= 0.1f)
        {
            targetReached = true;

            DealDamage();

            //change animation to destroying animation
            animator.SetBool("targetReached", true);

            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            return;
        }

        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
                                                 new Vector2(target.x, target.y), 
                                                 speed * Time.deltaTime);

    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
    }

    void DealDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);

        foreach(Collider2D nearbyObjects in colliders)
        {
            if(nearbyObjects.tag == "Enemy")
            {
                nearbyObjects.GetComponent<Enemy>().TakeDamage(damage, damageType);
            }
        }
    }
}
