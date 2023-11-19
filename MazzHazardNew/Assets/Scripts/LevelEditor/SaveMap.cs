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
    public bool grass;
}


public class SaveMap : MonoBehaviour
{
    [SerializeField] private Transform grid;
    public SavingData saveData;
    public static event Action<Dictionary<string, TileData>> OnSave;

    public void SaveMapData() 
    {
        for(int i = 0; i < grid.childCount; i++)
        {
            Transform tile = grid.GetChild(i);
            TileData data = new();

            data.spawner = tile.GetChild(0).gameObject.activeSelf;
            data.goal = tile.GetChild(1).gameObject.activeSelf;
            data.decor = tile.GetChild(2).gameObject.activeSelf;
            data.grass = tile.GetChild(3).gameObject.activeSelf;
            data.path = tile.GetChild(4).gameObject.activeSelf;
            data.range = tile.GetChild(5).gameObject.activeSelf;
           
            saveData.mapData[tile.name] = data;

        }

        OnSave?.Invoke(saveData.mapData);
    }
    //public void SaveToJSON()
    //{
    //    string json = JsonConvert.SerializeObject(saveData.mapData, Formatting.Indented);
    //    //string savePath = Application.streamingAssetsPath + "/" + saveFolder + "/" + fileName + ".json";
    //    string savePath = Application.streamingAssetsPath + "/"+ "LevelEditorFile" + fileName + ".json";
    //    int fileNumber = 0;

    //    while (File.Exists(savePath)) 
    //    {
    //      fileNumber++;
    //      savePath = Application.streamingAssetsPath + "/" + "LevelEditorFile" + fileName + fileNumber.ToString() + ".json";
    //    }
    //    File.WriteAllText(savePath, json);
    //}
}
