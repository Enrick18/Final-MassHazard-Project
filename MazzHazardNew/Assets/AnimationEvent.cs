using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationEvent : MonoBehaviour
{
    public HeroController hero;
    public EnemyController enemy;
    public HeroRangeAttack heroRange;
    public EnemyRangeAttack enemyRange;
    public HealerTower healer;


    public void DamageHit()
    {
        Debug.Log("HeroHit");
        hero?.DealDamage();
    }

    public void FireProjectile()
    {
        heroRange?.FireAttack();

    }

    public void EnemyProjectile() 
    { 
        enemyRange?.FireProjectile();
    }

    public void EnemyHit()
    {
        enemy?.EnemyDealDamage();
    }


    public void AttackStart() 
    {
        enemyRange?.StopMoving();
        
    }

    public void AttackEnd() 
    {
        enemyRange?.ResumeMoving();
       
    }


    public void HealHit() 
    {
        Debug.Log("Healed");
    }
}
