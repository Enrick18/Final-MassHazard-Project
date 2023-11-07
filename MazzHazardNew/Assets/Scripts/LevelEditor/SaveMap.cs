using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;

[Serializable] public class TileData
{
    public bool spawner;
    public bool goal;
    public bool decor;
    public bool path;
    public bool range;
}


public class SaveMap : MonoBehaviour
{
    [SerializeField] private string saveFolder = "CustomMaps";
    [SerializeField] private Transform grid;
    [SerializeField] private InputField enteredName;
    private Dictionary<string , TileData> mapData = new();
    private string fileName = "New Map";
    public void SaveCurrentMap()
    {
        if (enteredName.text != "")
        {
            fileName = enteredName.text;
        }

        SaveMapData();
        SaveToJSON();
    }
    public void SaveMapData() 
    {
        for(int i = 0; i < grid.childCount; i++)
        {
            Transform tile = grid.GetChild(i);
            TileData data = new();

            data.spawner = tile.GetChild(0).gameObject.activeSelf;
            data.goal = tile.GetChild(1).gameObject.activeSelf;
            data.decor = tile.GetChild(2).gameObject.activeSelf;
            data.path = tile.GetChild(3).gameObject.activeSelf;
            data.range = tile.GetChild(4).gameObject.activeSelf;
            mapData[tile.name] = data;
        }
    }
    public void SaveToJSON()
    {
        string json = JsonConvert.SerializeObject(mapData, Formatting.Indented);
        string savePath = Application.dataPath + "/" + saveFolder + "/" + fileName + ".json";
        File.WriteAllText(savePath, json);
    }
}
