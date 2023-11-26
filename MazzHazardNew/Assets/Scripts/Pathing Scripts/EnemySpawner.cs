using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public List<EnemyList> enemyList = new List<EnemyList>();
    // public GameObject bossToSpawn;
    private Transform spawnPoint;
    public float timeBetweenSpawns = 2f;
    public float timeBetweenWaves = 10f;
    private float spawnCounter;

    private int bossCountDown;
    public bool isThereBoss;
    public bool isRandomized = false;

    private int totalEnemies = 0;

    public bool isHard;
    public bool isMedium;


    // Start is called before the first frame update
    void Start()
    {
        foreach(var enemy in enemyList)
        {
            totalEnemies += enemy.enemyCount;
        }

        spawnCounter = timeBetweenSpawns;
        spawnPoint = this.gameObject.transform.GetChild(0);

        if (!isRandomized)
            StartCoroutine(LinearSpawn());
        else
            StartCoroutine(RandomizedSpawn());

    }

    IEnumerator LinearSpawn()
    {
        foreach (var enemy in enemyList)
        {
            while (enemy.enemyCount > 0)
            {
                if (isMedium) 
                {
                    enemy.enemy.GetComponent<HealthController>().IsMedium();

                    if (enemy.enemy.GetComponent<EnemyController>() != null) 
                    { 
                        enemy.enemy.GetComponent<EnemyController>().IsMedium();
                    }
                    else if (enemy.enemy.GetComponent<EnemyRangeAttack>() != null) 
                    {
                        enemy.enemy.GetComponent<EnemyRangeAttack>().IsMedium();
                    }
                }
                else if (isHard) 
                {
                    enemy.enemy.GetComponent<HealthController>().IsHard();

                    if (enemy.enemy.GetComponent<EnemyController>() != null)
                    {
                        enemy.enemy.GetComponent<EnemyController>().IsHard();
                    }
                    else if (enemy.enemy.GetComponent<EnemyRangeAttack>() != null)
                    {
                        enemy.enemy.GetComponent<EnemyRangeAttack>().IsHard();
                    }
                }
                Instantiate(enemy.enemy, spawnPoint.position, spawnPoint.rotation);
                enemy.enemyCount--;
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    IEnumerator RandomizedSpawn()
    {
        for (int i = 0; i <= totalEnemies; i++)
        {
            var enemy = enemyList[Random.Range(0, enemyList.Count)];
            if (enemy.enemyCount > 0)
            {
                if (isMedium)
                {
                    enemy.enemy.GetComponent<HealthController>().IsMedium();

                    if (enemy.enemy.GetComponent<EnemyController>() != null)
                    {
                        enemy.enemy.GetComponent<EnemyController>().IsMedium();
                    }
                    else if (enemy.enemy.GetComponent<EnemyRangeAttack>() != null)
                    {
                        enemy.enemy.GetComponent<EnemyController>().IsMedium();
                    }
                }
                else if (isHard)
                {
                    enemy.enemy.GetComponent<HealthController>().IsHard();

                    if (enemy.enemy.GetComponent<EnemyController>() != null)
                    {
                        enemy.enemy.GetComponent<EnemyController>().IsHard();
                    }
                    else if (enemy.enemy.GetComponent<EnemyRangeAttack>() != null)
                    {
                        enemy.enemy.GetComponent<EnemyController>().IsHard();
                    }
                }

                Instantiate(enemy.enemy, spawnPoint.position, spawnPoint.rotation);
                enemy.enemyCount--;
                yield return new WaitForSeconds(timeBetweenSpawns);

            }
        }
    }


}

[System.Serializable]
public class EnemyList
{
    public GameObject enemy;
    public int enemyCount;
}