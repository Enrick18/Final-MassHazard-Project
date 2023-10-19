using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody theRB;

    public float moveSpeed;

    public GameObject impactEffect;

    public float damageAmount = 0;

    private bool hasDamage; // controls hit for one target delete if you want to have aoe

    public string targetTag;

    [HideInInspector]public ElementType element;

    // Start is called before the first frame update
    void Start()
    {
        theRB.velocity = transform.forward * moveSpeed;
    }


    private void OnTriggerEnter(Collider other) 
    {
        var enemyHealth = other.GetComponent<IHealthSystem>();
        if(other.tag == targetTag && !hasDamage)
        {
            enemyHealth.TakeDamage(damageAmount, enemyHealth.GetElementalDamageMultiplier(element,enemyHealth.GetElementType()), enemyHealth.GetDamageResistanceModifier());
            hasDamage=true;
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible() 
    {
        Destroy(gameObject);    
    }
}
