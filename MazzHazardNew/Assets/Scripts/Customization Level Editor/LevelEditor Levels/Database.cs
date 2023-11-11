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
    public LoadingData referrencedData;
    public ToSaveData mapDetails;

    private void Awake() 
    {
        var findData = GameObject.Find("LevelEditorData");
        referrencedData = findData.GetComponent<LoadingData>();

        mapDetails = referrencedData.currentMapSelected;
        Debug.Log(mapDetails);

        currency.defaultCurency = mapDetails.toSaveCapsuleCount;
        currency.currentCurrency = mapDetails.toSaveCapsuleCount;
        Debug.Log(currency.currentCurrency);
        health.maxLife = mapDetails.toSaveHpCount;
        health.currentLife = mapDetails.toSaveHpCount;
        Debug.Log(health.maxLife);

        //loop
        for(int i = 0; i<mapDetails.toSaveWaveCount; i++)
        {
            EnemyList enemyToSpawn = new EnemyList();
            enemyToSpawn.enemy = enemies.listOfEnemies[mapDetails.toSaveEnemyWaveIndex[i]];
            enemyToSpawn.enemyCount = mapDetails.toSaveNumberOfEnemies[i];

            enemiesToSpawn.Add(enemyToSpawn);
        }

        foreach(var enemy in enemiesToSpawn)
        {
            enemySpawner.enemyList.Add(enemy);
        }

        Debug.Log(enemySpawner.enemyList.Count);

        

    }

}
