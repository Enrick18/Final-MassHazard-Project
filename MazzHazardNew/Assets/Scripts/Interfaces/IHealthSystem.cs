using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthSystem 
{
    ElementType GetElementType();
    
    void ApplyElementalEffect(float mulitplier);
    void TakeDamage(float damageAmount, float mulitplier, float resistanceModifier);
    void PoisonDamage(float poisonDamage);
    float GetCurrentHealth();
    float GetMaxHealth();
    float GetDamageResistanceModifier();
    void HealDamage(float healAmount);

    float GetElementalDamageMultiplier(ElementType attacker, ElementType defender);
}
