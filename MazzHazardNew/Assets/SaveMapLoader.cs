using UnityEngine;
using System.IO;
using System.Collections.Generic;
using TMPro;

public class SaveMapLoader : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private RectTransform buttonPrefab;
    [SerializeField] private string folderPath = "CustomMaps"; 
    private List<string> savedMaps = new List<string>();


    void Start()
    {
        
        string fullPath = System.IO.Path.Combine(Application.dataPath, folderPath);

       
        if (Directory.Exists(fullPath))
        {
            
            string[] jsonFiles = Directory.GetFiles(fullPath, "*.json");

            foreach (string jsonFilePath in jsonFiles)
            {
                // Extract the file name from the path
                string fileName = System.IO.Path.GetFileNameWithoutExtension(jsonFilePath);
                savedMaps.Add(fileName);
            }

        }
        else
        {
            Debug.LogError("Directory not found: " + fullPath);
        }

        InstantiateButtons();
    }

    private void InstantiateButtons()
    {
        foreach (var saveMap in savedMaps)
        {
            var button = Instantiate(buttonPrefab);
            button.GetComponentInChildren<TextMeshProUGUI>().text = saveMap;
            button.SetParent(parent, false);
        }
    }

}