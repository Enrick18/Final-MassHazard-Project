using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRangeTower : MonoBehaviour, IKillable
{
    public float range = 10f;

    public LayerMask whatIsEnemy;
    private Collider[] colliderInRange;
    public List<EnemyMove> enemiesInRange = new List<EnemyMove>();

    private float checkCounter;
    public float checkTime = .2f;
    [HideInInspector]
    public bool enemiesUpdated;

    // Start is called before the first frame update
    void Start()
    {
        checkCounter = checkTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdated = false; 

        checkCounter -= Time.deltaTime;
        if(checkCounter <= 0)
        {
            checkCounter = checkTime;

            colliderInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

            enemiesInRange.Clear();

            foreach(Collider col in colliderInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyMove>());
            }

            enemiesUpdated = true;
        }

        
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    
    public void IsDead()
    {
        this.enabled = false;
    }



}
