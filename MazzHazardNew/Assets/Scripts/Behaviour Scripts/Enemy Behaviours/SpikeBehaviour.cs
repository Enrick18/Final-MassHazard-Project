using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehaviour : MonoBehaviour
{
    public float damageAmount = 10f;
    [HideInInspector]public ElementType element;
    public string targetTag;
    private IHealthSystem treantHealth;

    private void Start()
    {
        treantHealth = GetComponent<IHealthSystem>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        // Check if the spikes collide with an enemy.
        if (other.tag == targetTag)
        {
            
            // Damage the enemy and destroy the spikes.
            var heroHealth = other.GetComponent<HealthController>();
            
            if (heroHealth != null)
            {
                heroHealth.TakeDamage(damageAmount, heroHealth.GetElementalDamageMultiplier(element, heroHealth.GetElementType()), heroHealth.GetDamageResistanceModifier());
            }
            Destroy(gameObject, 1f);
        }
    }
}
