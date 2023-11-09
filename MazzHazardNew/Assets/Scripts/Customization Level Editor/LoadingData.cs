using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;


public class LoadingData : MonoBehaviour
{
    public List<ToSaveData> data = new List<ToSaveData>();
    public ToSaveData currentMapSelected;
    public string searchPattern;
    public string[] filePaths;
    public GameObject parentObject;
    public GameObject levelEditButton;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        searchPattern = "LevelEditor*.json";
        filePaths = Directory.GetFiles(Application.streamingAssetsPath, searchPattern);
        LoadJson();
        for (int i = 0; i < data.Count; i++)
        {
            GameObject button = Instantiate(levelEditButton, parentObject.transform);
            var buttonComponent = button.GetComponent<MapSceneToLoad>();
            buttonComponent.mapName = data[i].toSaveMapSelected;
            buttonComponent.dataHolder = data[i];
            buttonComponent.fileName = data[i].toSavefinalMapName;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the specific scene has been loaded
        if (scene.name == "LevelEditor")
        {
            // Call your method here
            YourMethod();
        }
    }

    private void YourMethod()
    {
        // Your code here
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadJson()
    {
        if (filePaths.Length > 0)
        {
            for (int i = 0; i < filePaths.Length; i++)
            {
                string json = File.ReadAllText(filePaths[i]);
                ToSaveData tempdata = JsonConvert.DeserializeObject<ToSaveData>(json);
                Debug.Log(json);
                data.Add(tempdata);
            }
        }
    }

    public void CurrentMapSelected(ToSaveData data)
    {
        currentMapSelected = data;
    }
}
