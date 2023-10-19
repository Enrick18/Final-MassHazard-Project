using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    private EnemyRange enemyRange;
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

    // Start is called before the first frame update
    void Start()
    {
        enemyRange = GetComponent<EnemyRange>();
    }

    // Update is called once per frame
    void Update()
    {
        // to look at target without rotating the x and z value
        if (target != null)
        {
            launcherModel.rotation = Quaternion.Slerp(launcherModel.rotation, Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);
        }

        shotCounter -= Time.deltaTime;
        // Firing of shots to enemy
        if (shotCounter <= 0 && target != null)
        {
            shotCounter = timeBetweenShots;
            firePoint.LookAt(target);
            anim.SetBool("isAttacking", true);
            anim.SetBool("isWalking", false);
            var bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Projectile>().element = element;
            bullet.GetComponent<Projectile>().damageAmount = damage;

        }

        if (enemyRange.enemiesUpdated) // for optimising purposes so that it wont check closest enemy every frame
        {
            //Assign a target from the data given by theTower code
            if (enemyRange.enemiesInRange.Count > 0)
            {
                anim.SetBool("isAttacking", true);
                float minDistance = enemyRange.range + 1f;

                foreach (HeroDetect enemy in enemyRange.enemiesInRange)
                {
                    if (enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            target = enemy.transform;
                        }

                    }
                }
            }
            else
            {
                target = null;
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", true);
            }
        }
    }


    public void IsDead()
    {
        this.enabled = false;
    }

}
