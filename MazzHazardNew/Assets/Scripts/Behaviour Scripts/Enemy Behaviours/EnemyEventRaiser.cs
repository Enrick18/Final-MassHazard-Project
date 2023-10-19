using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventRaiser : MonoBehaviour
{
    GameObject enemyCounter;
    EnemyCounter counter;
    // Start is called before the first frame update
    void Start()
    {
        enemyCounter = GameObject.Find("EnemyCounter");
        counter = enemyCounter.GetComponent<EnemyCounter>();

    }

    public void SendDeathEvent()
    {
        counter.SendMessage("DecreaseEnemy");
    }
}
