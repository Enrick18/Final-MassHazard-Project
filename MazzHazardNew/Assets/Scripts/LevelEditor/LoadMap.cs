using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;
using JetBrains.Annotations;
using Unity.AI.Navigation;

public class LoadMap : MonoBehaviour
{
    [SerializeField] private NavMeshSurface navMeshSurface;
    private string fileName = "New Map"; // Provide the name of the JSON file
    private Dictionary<string, TileData> mapData = new Dictionary<string, TileData>();
    public MapData mapName = null;
    public SavingData saveData;
    public static event Action OnMapLoaded;

    private void OnEnable()
    {
        mapData = saveData.mapData;
        SaveMap.OnSave += BuildMap;
        
    }

    private void OnDisable()
    {
        SaveMap.OnSave -= BuildMap;
    }

    private void BuildMap()
    {
        fileName = mapName.mapName;

        //LoadFromJSON();

        if (mapData.Count > 0) { 
            for (int i = 0; i < transform.childCount; i++) 
            { 
                var parentCube = transform.GetChild(i);
                parentCube.GetChild(0).gameObject.SetActive(mapData[parentCube.name.ToString()].spawner);
                parentCube.GetChild(1).gameObject.SetActive(mapData[parentCube.name.ToString()].goal);
                parentCube.GetChild(2).gameObject.SetActive(mapData[parentCube.name.ToString()].decor);
                parentCube.GetChild(3).gameObject.SetActive(mapData[parentCube.name.ToString()].grass);
                parentCube.GetChild(4).gameObject.SetActive(mapData[parentCube.name.ToString()].path);
                parentCube.GetChild(5).gameObject.SetActive(mapData[parentCube.name.ToString()].range);
                
            }
        }

        navMeshSurface.BuildNavMesh();

        OnMapLoaded?.Invoke();
    }

    //public void LoadFromJSON()
    //{
    //    string filePath = Application.streamingAssetsPath + "/CustomMaps/" + fileName + ".json";

    //    if (File.Exists(filePath))
    //    {
    //        string json = File.ReadAllText(filePath);
    //        mapData = JsonConvert.DeserializeObject<Dictionary<string, TileData>>(json);

            
    //        // Now mapData contains the deserialized data from the JSON file
    //        // You can access it like mapData["tileName"].spawner, mapData["tileName"].goal, etc.
    //    }
    //    else
    //    {
    //        Debug.LogError("JSON file not found: " + filePath);
    //    }


    //}



}