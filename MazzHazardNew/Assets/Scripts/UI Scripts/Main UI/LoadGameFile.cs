using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class LoadGameFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loading");
        string json = File.ReadAllText(Application.streamingAssetsPath + "/" + "SaveGameData"+ ".json");
        SaveData data = JsonConvert.DeserializeObject<SaveData>(json);

        PlayerPrefs.SetInt(data.easyLevelKey, data.easyLevelValue);
        PlayerPrefs.SetInt(data.mediumLevelKey, data.mediumLevelValue);
        PlayerPrefs.SetInt(data.hardLevelKey, data.hardLevelValue);
    }

    
}
