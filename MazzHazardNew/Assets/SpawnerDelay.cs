using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDelay : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private int delay;

    private void OnEnable()
    {
        LoadMap.OnMapLoaded += DelaySpawn;
    }

    private void OnDisable()
    {
        LoadMap.OnMapLoaded -= DelaySpawn;
    }

    public void DelaySpawn() 
    {
        spawner.enabled = false;
        Invoke(nameof(EnableSpawner), delay);
    }
    void Start()
    {
        spawner.enabled = false;
        Invoke(nameof(EnableSpawner), delay);
    }

    void EnableSpawner()
    {
        spawner.enabled = true;
    }
}
