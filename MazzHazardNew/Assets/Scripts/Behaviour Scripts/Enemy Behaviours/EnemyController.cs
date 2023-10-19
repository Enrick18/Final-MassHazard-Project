using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IKillable
{
    public string targetTag;
    public float damageAmount;
    public float timeBetweenAttacks = 1f;
    private float attackCounter;
    private GameObject hero;
    public Animator anim;
    [HideInInspector]public bool isBuffApplied { get; set; }

    //Enemy Melee Anim

    private IHealthSystem enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<IHealthSystem>();

    }

    // Update is called once per frame
    void Update()
    {

        if (hero == null)// to resume movement when no hero blocking
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == targetTag)
        {
            hero = other.gameObject;
            attackCounter -= Time.deltaTime;
            var heroHealth = hero.GetComponent<IHealthSystem>();
            if (attackCounter <= 0)
            {
                attackCounter = timeBetweenAttacks;
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
                //Attack anim
                heroHealth.TakeDamage(damageAmount, heroHealth.GetElementalDamageMultiplier(enemyHealth.GetElementType(), heroHealth.GetElementType()), heroHealth.GetDamageResistanceModifier());
            }
        }

    }

    public void IsDead()
    {
        this.enabled = false;
    }
}
