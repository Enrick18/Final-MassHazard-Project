using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Difficulty{easy, medium, hard}
public class EnemyCounter : MonoBehaviour
{

    public Difficulty difficulty;
    public Text enemyCount;
    public EnemySpawner enemySpawner;
    public int currentEnemyCount = 0;
    public GameObject winUi;

    public StageComplete levelComplete;
    // public int level;

    //private void Start()
    //{
    //    enemySpawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
    //    Debug.Log(enemySpawner);
    //}

    private void Update() {
        if(currentEnemyCount <= 0)
        {
            Debug.Log("You Win");
            winUi.SetActive(true);
            levelComplete.SaveProgress();
           
            SaveStage.SaveGameFile();
            Time.timeScale = 0f;
        }
    }


    private void Start() 
    {
        enemySpawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();

        foreach (var enemy in enemySpawner.enemyList)
        {
            
            currentEnemyCount += enemy.enemyCount;
            
        }
        enemyCount.text = currentEnemyCount.ToString();
    }

    public void DecreaseEnemy()
    {
        currentEnemyCount--;
        enemyCount.text = currentEnemyCount.ToString();
        Debug.Log(currentEnemyCount);
    }

}
