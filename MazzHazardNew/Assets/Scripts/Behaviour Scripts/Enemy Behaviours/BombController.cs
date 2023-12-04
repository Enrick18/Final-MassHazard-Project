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
    [SerializeField]private bool isMedium;
    [SerializeField]private bool isHard;

    public void IsDead()
    {
        this.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isMedium)
        {
            float damageIncrease = 50f;
            damageAmount += damageIncrease;
        }
        else if (isHard)
        {
            float damageIncrease = 100f;
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

    }

    // Update is called once per frame
    public void Explode()
    {

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, bombRadius, heroLayer);

            foreach (Collider col in hitColliders) 
            {
                //boomEffect.Play();
                Debug.Log("Boom");
                Instantiate(explosion, transform.position, transform.rotation);
                var heroHealth = col.GetComponent<HealthController>();
                heroHealth.TakeDamage(damageAmount, heroHealth.GetElementalDamageMultiplier(enemyHealth.GetElementType(), heroHealth.GetElementType()), heroHealth.GetDamageResistanceModifier());
            }

    }

    private void OnTriggerEnter(Collider other)
    {
        Explode();
        healthController.Dead();
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bombRadius);
    }
}
