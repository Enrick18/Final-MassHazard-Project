using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class DeleteJson : MonoBehaviour
{
    public MapData mapDataSO = null;
    private string fileName;
    public Transform parent;

    private List<string> savedMaps = new();
    [SerializeField]private RectTransform buttonPrefab;
    public void DeleteFile() 
    {
        fileName = mapDataSO.mapName;

        string filePath = Application.streamingAssetsPath + "/" + fileName + ".json";

        if (File.Exists(filePath)) 
        { 
            File.Delete(filePath);
        }

        for (int i = 0; i < parent.childCount; i++) 
        {
            Destroy(parent.GetChild(i).gameObject);
        }

        InstantiateNewButtons();
    }

    public void InstantiateNewButtons() 
    {
        string fullPath = System.IO.Path.Combine(Application.streamingAssetsPath); System.IO.Path.Combine(Application.streamingAssetsPath);

        if (Directory.Exists(fullPath))
        {
            string[] jsonFiles = Directory.GetFiles(fullPath, "*.json");

            foreach (string jsonFilePath in jsonFiles)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(jsonFilePath);
                savedMaps.Add(fileName);
            }
        }
        else 
        {
            Debug.Log("Directory cant be found");
        }

        foreach (var saveMap in savedMaps)
        {
            var button = Instantiate(buttonPrefab);
            button.GetComponentInChildren<TextMeshProUGUI>().text = saveMap;
            button.SetParent(parent, false);
        }
    }


}
