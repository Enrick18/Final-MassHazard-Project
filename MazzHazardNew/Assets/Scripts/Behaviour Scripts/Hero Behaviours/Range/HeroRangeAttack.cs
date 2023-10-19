using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRangeAttack : MonoBehaviour, IKillable, IHeroStats
{
    private HeroRangeTower theTower;
    public GameObject projectile;
    public Transform firePoint;
    public float timeBetweenShots = 1f;
    private float shotCounter;

    [SerializeField]private Transform target;
    public Transform launcherModel;

    public Animator anim;

    [SerializeField]private ElementType element;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<HeroRangeTower>();
    }

    // Update is called once per frame
    void Update()
    {
        // to look at target without rotating the x and z value
        if(target != null)
        {
            // launcherModel.LookAt(target);
            launcherModel.rotation = Quaternion.Slerp (launcherModel.rotation, Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);
        }


        shotCounter -= Time.deltaTime;
        // Firing of shots to enemy
        if(shotCounter <= 0 && target != null)
        {
            shotCounter = timeBetweenShots;
            firePoint.LookAt(target);
            anim.SetBool("isIdle",false);
            anim.SetBool("isAttacking", true);

            GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Projectile>().element = element; //sets the element of the hero to the bullet
            bullet.GetComponent<Projectile>().damageAmount = damage;
        }

        if(theTower.enemiesUpdated) // for optimising purposes so that it wont check closest enemy every frame
        {
            //Assign a target from the data given by theTower code
            if(theTower.enemiesInRange.Count > 0)
            {
                anim.SetBool("isAttacking", true);
                float minDistance = theTower.range + 1f;

                foreach(EnemyMove enemy in theTower.enemiesInRange)
                {
                    if(enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if(distance < minDistance)
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
                anim.SetBool("isIdle", true);        
            }
        }    
    }


    public void IsDead()
    {
        this.enabled = false;
    }

    public void ModifyHeroDamage(float multiplier)
    {
        damage *= multiplier;
    }
}
