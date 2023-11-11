using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSceneToLoad : MonoBehaviour
{
    public ToSaveData dataHolder = new ToSaveData();
    public string mapName;
    public string fileName;
    public void LoadMapName()
    {
        SceneManager.LoadScene(mapName);

        var scriptHolder = GameObject.Find("LevelEditorData");
        var loadData = scriptHolder.GetComponent<LoadingData>();

        loadData.CurrentMapSelected(dataHolder);

    }
}
