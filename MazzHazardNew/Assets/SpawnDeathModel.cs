using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeathModel : MonoBehaviour
{
    private void OnEnable()
    {
        HealthController.OnSpawnDestroyedModel += ReplaceModel;
    }

    private void OnDisable()
    {
        HealthController.OnSpawnDestroyedModel -= ReplaceModel;
    }

    public void ReplaceModel(HealthController.SpawnModelDetails modelDetails) 
    {
        Debug.Log("Spawned");
        GameObject model = modelDetails.model;
        Transform spawnPoint = modelDetails.spawnPoint;

        Debug.Log(model);
        Debug.Log(spawnPoint);

        Instantiate(model, spawnPoint.position, spawnPoint.rotation);

    }
}
