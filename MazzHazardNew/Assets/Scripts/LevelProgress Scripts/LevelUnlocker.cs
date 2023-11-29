using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    public int levelIndex;
    public int maxEasyLevel = 2;
    public int maxMediumLevel = 2;
    public string levelName;

    public List<GameObject> easyLevelButtons = new List<GameObject>();
    public List<GameObject> mediumLevelButtons = new List<GameObject>();
    public List<GameObject> hardLevelButtons = new List<GameObject>();



    void Start()
    {
        EnableButtons("EasyLevel", easyLevelButtons);
        EnableButtons("MediumLevel", mediumLevelButtons);
        EnableButtons("HardLevel", hardLevelButtons);
        
    }

    public void EnableButtons(string levelKey, List<GameObject> buttons)
    {
        for (int i = 0; i < PlayerPrefs.GetInt(levelKey); i++)
        {
            buttons[i].SetActive(true);
        }
    }
}
