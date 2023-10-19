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
        //     if (levelName == "EasyLevel") {
        //         int currentLevel = PlayerPrefs.GetInt(levelName, 1);
        //         Debug.Log("EasyLevel "+currentLevel);
        //         if (currentLevel >= levelIndex)
        //         {
        //             easyLevelButtons[levelIndex].SetActive(true);
        //         }
        //         else
        //         {
        //             easyLevelButtons[levelIndex].SetActive(false);
        //         }
        //     }
        //     else if (levelName == "MediumLevel")
        //     {
        //         int currentEasyLevel = PlayerPrefs.GetInt("EasyLevel", 1);
        //         int currentLevel = PlayerPrefs.GetInt(levelName, 1);
        //         Debug.Log("MediumLevel " + currentLevel);
        //         if (currentEasyLevel > maxEasyLevel)
        //         {
        //             if (currentLevel >= levelIndex)
        //             {
        //                 mediumLevelButtons[levelIndex].SetActive(true);
        //             }
        //             else
        //             {
        //                 mediumLevelButtons[levelIndex].SetActive(false);
        //             }
        //         }
        //         else
        //         {
        //             mediumLevelButtons[levelIndex].SetActive(false);
        //         }
        //     }
        //     else if (levelName == "HardLevel")
        //     {
        //         int currentMediumLevel = PlayerPrefs.GetInt("MediumLevel", 1);
        //         int currentLevel = PlayerPrefs.GetInt(levelName, 1);
        //         Debug.Log("HardLevel " + currentLevel);
        //         if (currentMediumLevel > maxMediumLevel)
        //         {
        //             if (currentLevel >= levelIndex)
        //             {
        //                 hardLevelButtons[levelIndex].SetActive(true);
        //             }
        //             else
        //             {
        //                 hardLevelButtons[1].SetActive(false);
        //             }
        //         }
        //         else
        //         {
        //             hardLevelButtons[1].SetActive(false);
        //         }
        //     }
    }

    public void EnableButtons(string levelKey, List<GameObject> buttons)
    {
        for (int i = 0; i < PlayerPrefs.GetInt(levelKey); i++)
        {
            buttons[i].SetActive(true);
        }
    }
}
