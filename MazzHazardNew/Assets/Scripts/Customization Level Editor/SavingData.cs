using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SavingData : MonoBehaviour
{
    public LevelEditor levelEditorData;
    public Dictionary<string, TileData> mapData = new();
    public void SaveJson()
    {
        ToSaveData data = new ToSaveData();
        //Data to save
        //data.toSaveMapSelected = levelEditorData.mapSelected;
        data.toSaveGameModeSelected = levelEditorData.gameModeSelected;
        for(int i=0; i<5; i++)
        {
            data.toSaveEnemyWaveIndex[i] = levelEditorData.enemyWaveIndex[i];
            data.toSaveNumberOfEnemies[i] = levelEditorData.numberOfEnemies[i];
        }
        data.toSaveWaveCount = levelEditorData.waveCount;
        data.toSaveHpCount = levelEditorData.hpCount;
        data.toSaveCapsuleCount = levelEditorData.capsuleCount;
        data.toSavefinalMapName = levelEditorData.finalMapName;
        data.toSaveIsRogue = levelEditorData.isRogue;


        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        string filePath = Application.streamingAssetsPath + "/" + "LevelEditorFile_"+ levelEditorData.finalMapName +".json";
        int fileNummber = 0;
        while(File.Exists(filePath))
        {
            fileNummber++;
            filePath = Application.streamingAssetsPath + "/" + "LevelEditorFile_"+ levelEditorData.finalMapName +fileNummber.ToString()+".json";
        }
        File.WriteAllText(filePath, json);
    }
}
public class ToSaveData
{
    public string toSaveMapSelected;
    public string toSaveGameModeSelected;
    public int toSaveWaveCount;
    public int[] toSaveEnemyWaveIndex = new int[5];
    public int[] toSaveNumberOfEnemies = new int[5];
    public int toSaveHpCount;
    public int toSaveCapsuleCount;
    public string toSavefinalMapName;
    public bool toSaveIsRogue;
}

