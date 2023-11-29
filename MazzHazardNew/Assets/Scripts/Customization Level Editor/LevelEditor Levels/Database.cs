using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public List<EnemyList> enemiesToSpawn;
    public ListOfEnemies enemies;
    public CurrencySystem currency;
    public GoalTrigger health;
    public LoadMap referrencedData;
    public static event Action dataBaseLoaded;

    private void OnEnable()
    {
        LoadMap.OnMapLoaded += SetData;
    }

    private void OnDisable()
    {
        LoadMap.OnMapLoaded -= SetData;
    }

    private void SetData() 
    {
        enemySpawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
        health = GameObject.Find("Goal").GetComponentInChildren<GoalTrigger>();
        Debug.Log(enemySpawner);

        if (referrencedData.customMapData.toSaveIsRogue) 
        {
            enemySpawner.isRandomized = true;
        }
        
        currency.defaultCurency = referrencedData.customMapData.toSaveCapsuleCount;
        currency.currentCurrency = referrencedData.customMapData.toSaveCapsuleCount;
        Debug.Log(currency.currentCurrency);
        health.maxLife = referrencedData.customMapData.toSaveHpCount;
        health.currentLife = referrencedData.customMapData.toSaveHpCount;

        //loop
        for(int i = 0; i< referrencedData.customMapData.toSaveWaveCount; i++)
        {
            EnemyList enemyToSpawn = new EnemyList();
            enemyToSpawn.enemy = enemies.listOfEnemies[referrencedData.customMapData.toSaveEnemyWaveIndex[i]];
            enemyToSpawn.enemyCount = referrencedData.customMapData.toSaveNumberOfEnemies[i];

            enemiesToSpawn.Add(enemyToSpawn);
        }

        foreach(var enemy in enemiesToSpawn)
        {
            enemySpawner.enemyList.Add(enemy);
        }

        //Debug.Log(enemySpawner.enemyList.Count);
        dataBaseLoaded?.Invoke();
    }

}
