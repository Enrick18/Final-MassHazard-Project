using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour, IKillable
{
    [SerializeField] private AudioSource boomEffect;

    private HealthController healthController;
    private IHealthSystem enemyHealth;
    public float bombRadius;
    public LayerMask heroLayer;
    public float damageAmount;
    public GameObject explosion;
    public Animator anim;
    private bool isMedium;
    private bool isHard;

    public void IsDead()
    {
        this.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isMedium)
        {
            float damageIncrease = damageAmount * 0.15f;
            damageAmount += damageIncrease;
        }
        else if (isHard)
        {
            float damageIncrease = damageAmount * 0.40f;
            damageAmount += damageIncrease;
        }
        healthController = GetComponent<HealthController>();
        enemyHealth = GetComponent<IHealthSystem>();
        anim.SetBool("isWalking", true);
    }

    public bool IsMedium() { isMedium = true; return isMedium; }
    public bool IsHard() { isHard = true; return isHard; }

    private void Update()
    {
        if (healthController.currentHealth <= 0) 
        { 
            Explode();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void Explode()
    {
            Instantiate(explosion, transform.position, transform.rotation);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, bombRadius, heroLayer);

            foreach (Collider col in hitColliders) 
            {
                boomEffect.Play();
                Debug.Log("Boom");
                var heroHealth = col.GetComponent<HealthController>();
                heroHealth.TakeDamage(damageAmount, heroHealth.GetElementalDamageMultiplier(enemyHealth.GetElementType(), heroHealth.GetElementType()), heroHealth.GetDamageResistanceModifier());
            }

    }

    private void OnTriggerEnter(Collider other)
    {
        Explode();
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bombRadius);
    }
}
