using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantAoeAttack : MonoBehaviour
{
    [SerializeField] private AudioSource BossBuffEffect;
    [SerializeField] private AudioSource BossPoisonTarget;

    public LayerMask hero;
    public LayerMask enemy;
    public float range;
    public string attackTargetTag = "Hero";
    public float damageInterval = 1.5f;
    public float poisonDamage = 10f;
    public float damageBuff = 1;

    private float timer = 0f;

    private void Update()
    {
        Collider[] enemyCollider = Physics.OverlapSphere(transform.position, range, enemy);

        foreach (Collider collider in enemyCollider)
        {
            BossBuffEffect.Play();
            EnemyController enemyController = collider.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                if (!enemyController.isBuffApplied) 
                {
                    enemyController.damageAmount *= damageBuff;
                    enemyController.isBuffApplied = true;
                }
                
            }

            EnemyRangeAttack enemyRangeAttack = collider.GetComponent<EnemyRangeAttack>();

            if (enemyRangeAttack != null)
            {
                if (!enemyRangeAttack.isBuffApplied) 
                {
                    enemyRangeAttack.damage *= damageBuff;
                    enemyRangeAttack.isBuffApplied=true;
                }
                
            }
        }

        timer += Time.deltaTime;

        if (timer >= damageInterval)
        {
                timer = 0f;
                PoisonDamage();    
        }
    }

    private void PoisonDamage()
    {
        Collider[] heroCollider = Physics.OverlapSphere(transform.position, range, hero);
        
        foreach (Collider collider in heroCollider)
        {
            BossPoisonTarget.Play();
            if (collider.CompareTag(attackTargetTag))
            {
                // Implement your health reduction logic here
                var heroHealth = collider.GetComponent<IHealthSystem>();
                if (heroHealth != null)
                {
                    heroHealth.PoisonDamage(poisonDamage);
                }
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
