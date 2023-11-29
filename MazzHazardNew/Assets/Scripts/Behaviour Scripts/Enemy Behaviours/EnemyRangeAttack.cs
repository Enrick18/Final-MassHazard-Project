using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRangeAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;

    public float timeBetweenShots = 1f;
    private float shotCounter;

    public float damage;

    [SerializeField] private Transform target;
    [SerializeField] private ElementType element;
    [HideInInspector] public bool isBuffApplied { get; set; }

    public Transform launcherModel;

    public Animator anim;

    private NavMeshAgent agent;
    private float moveSpeed;

    private bool isMedium;
    private bool isHard;

    public float detectionRadius = 10f;
    public float attackRange = 10f;
    public LayerMask heroLayer;

    private EnemyMove enemyMove;

    // Start is called before the first frame update

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        moveSpeed = agent.speed;
        if (isMedium)
        {
            float damageIncrease = damage * 0.15f;
            damage += damageIncrease;
        }
        else if (isHard)
        {
            float damageIncrease = damage * 0.40f;
            damage += damageIncrease;
        }

        enemyMove = GetComponent<EnemyMove>();
    }

    public bool IsMedium() { isMedium = true; return isMedium; }
    public bool IsHard() { isHard = true; return isHard; }

    // Update is called once per frame
    void Update()
    {
        if (target == null || Vector3.Distance(transform.position, target.position) > attackRange) 
        { 

            DetectNearestEnemy();
        }

        LookAtTarget();

        if (target != null)
        {
            shotCounter -= Time.deltaTime;

            if (target != null && shotCounter <= 0)
            {
                enemyMove.StopEnemy(target.gameObject);
                shotCounter = timeBetweenShots;
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);

            }
        }


        if (target == null) 
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", true);
        }
    }

    void DetectNearestEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, heroLayer);

        float nearestDistance = Mathf.Infinity;
        Transform newTarget = null;

        foreach (Collider col in hitColliders)
        {
            float distance = Vector3.Distance(transform.position, col.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                newTarget = col.transform;
            }
        }

        target = newTarget;
    }

    void LookAtTarget()
    {
        if (target != null)
        {
            //transform.LookAt(target);
            launcherModel.rotation = Quaternion.Slerp(launcherModel.rotation, Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);
        }
    }

    public void FireProjectile() 
    {
        Debug.Log("Fire");
        var bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Projectile>().element = element;
        bullet.GetComponent<Projectile>().damageAmount = damage;
    }

    public void IsDead()
    {
        this.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}
