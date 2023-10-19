using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour, IHealthSystem
{
    public Slider healthBar;
    public float maxHealth;
    public float currentHealth;
    private float healDmg;
    private Animator anim;

    [SerializeField] private float damageResistance = 1;
    [SerializeField] private ElementType element;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Dead();
        }


        healthBar.transform.rotation = Camera.main.transform.rotation;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.value = currentHealth;
    }

    public void TakeDamage(float damageAmount, float multiplier, float resistanceModifier)
    {
        damageAmount *= multiplier;
        damageAmount *= resistanceModifier;
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Dead();
        }

    }

    public void PoisonDamage(float poisonDamage)
    {
        currentHealth -= poisonDamage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Dead();
        }
    }

    public void HealDamage(float healAmount)
    {
        healDmg = healAmount;

        Invoke(nameof(Heal), .2f);

    }

    void Heal()
    {
        currentHealth += healDmg;

    }

    public void Dead()
    {
        if (anim != null)
        {
            anim.SetBool("isDead", true);
            var killableComponents = GetComponents<IKillable>();
            foreach (var killable in killableComponents)
            {
                // Debug.Log(killable);
                killable.IsDead();
            }
        }
        Destroy(gameObject);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetDamageResistanceModifier()
    {
        return damageResistance;
    }


    public float GetElementalDamageMultiplier(ElementType attacker, ElementType defender)
    {
        if (attacker == ElementType.Normal)
        {
            return 1f;
        }
        else if (attacker == defender)
        {
            return 0.5f;
        }
        else
        {
            switch (attacker)
            {
                case ElementType.Fire:
                    switch (defender)
                    {
                        case ElementType.Plant:
                            return 2f;
                        case ElementType.Water:
                            return 0.5f;
                        default:
                            return 1f;
                    }
                case ElementType.Water:
                    switch (defender)
                    {
                        case ElementType.Fire:
                            return 2f;
                        case ElementType.Plant:
                            return 0.5f;
                        default:
                            return 1f;
                    }
                case ElementType.Plant:
                    switch (defender)
                    {
                        case ElementType.Water:
                            return 2f;
                        case ElementType.Fire:
                            return 0.5f;
                        default:
                            return 1f;
                    }
                default:
                    return 1f;
            }
        }
    }

    public ElementType GetElementType()
    {
        return element;
    }

    public void ApplyElementalEffect(float mulitplier)
    {
        maxHealth *= mulitplier;
        currentHealth *= mulitplier;
    }

    
}
