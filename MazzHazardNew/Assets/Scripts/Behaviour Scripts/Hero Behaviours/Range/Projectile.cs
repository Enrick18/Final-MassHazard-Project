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
    [SerializeField]private bool isAoe = false;

    public string targetTag;

    [HideInInspector]public ElementType element;

    [SerializeField] private bool isHero;

    // Start is called before the first frame update
    void Start()
    {
        theRB.velocity = transform.forward * moveSpeed;
    }


    private void OnTriggerEnter(Collider other) 
    {
        var enemyHealth = other.GetComponent<IHealthSystem>();

        if (other.tag == targetTag)
        {
            if (isAoe == false)
            {
                if (!hasDamage)
                {
                    enemyHealth.TakeDamage(damageAmount, enemyHealth.GetElementalDamageMultiplier(element, enemyHealth.GetElementType()), enemyHealth.GetDamageResistanceModifier());
                    hasDamage = true;
                }
            }
            else
            {
                enemyHealth.TakeDamage(damageAmount, enemyHealth.GetElementalDamageMultiplier(element, enemyHealth.GetElementType()), enemyHealth.GetDamageResistanceModifier());
            }
        }
        else if (other.tag == "HeroHealer" && !isHero) 
        {
            if (isAoe == false)
            {
                if (!hasDamage)
                {
                    enemyHealth.TakeDamage(damageAmount, enemyHealth.GetElementalDamageMultiplier(element, enemyHealth.GetElementType()), enemyHealth.GetDamageResistanceModifier());
                    hasDamage = true;
                }
            }
            else
            {
                enemyHealth.TakeDamage(damageAmount, enemyHealth.GetElementalDamageMultiplier(element, enemyHealth.GetElementType()), enemyHealth.GetDamageResistanceModifier());
            }
        }

        if (isHero)
        {
            if (other.tag == targetTag || other.tag == "Tile" || other.tag == "Decor" || other.tag == "HeroHealer" || other.tag == "Tree")
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else 
        {
            if (other.tag == targetTag || other.tag == "Tile" || other.tag == "Decor" || other.tag == "HeroHealer")
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        Destroy(gameObject, 5f);
        
    }

    private void OnBecameInvisible() 
    {
        Destroy(gameObject);    
    }
}
