using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public static class SaveStage 
{
    // Start is called before the first frame update
    public static void SaveGameFile()
    {
        Debug.Log("Saving");
        SaveData data = new SaveData();
        data.easyLevelKey = "EasyLevel";
        data.easyLevelValue = PlayerPrefs.GetInt(data.easyLevelKey, 1);
        data.mediumLevelKey = "MediumLevel";
        data.mediumLevelValue = PlayerPrefs.GetInt(data.mediumLevelKey, 1);
        data.hardLevelKey = "HardLevel";
        data.hardLevelValue = PlayerPrefs.GetInt(data.hardLevelKey, 1);
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        string filePath = Application.streamingAssetsPath + "/" + "SaveGameData"+ ".json";

        File.WriteAllText(filePath, json);
    }

}

public class SaveData
{
    public string easyLevelKey;
    public int easyLevelValue;
    public string mediumLevelKey;
    public int mediumLevelValue;
    public string hardLevelKey;
    public int hardLevelValue;

}
