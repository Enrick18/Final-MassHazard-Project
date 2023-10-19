using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public GameObject stageUi;
    public GameObject loadOutUi;
    public LoadOutHeroList heroList;
    public GameObject warningUi;
    public void SetLevelToLoad(string level)
    {
        stageUi.SetActive(false);
        loadOutUi.SetActive(true);
        MissionSelect.levelToLoad = level;
    }

    public void LoadLevel()
    {


        for(int i = 0; i < heroList.heroChoosenIndex.Count; i++)
        {
            if(heroList.heroChoosenIndex[i] != -1)
            {
                SceneManager.LoadScene(MissionSelect.levelToLoad);
            }
            else
            {
                warningUi.SetActive(true);
            }
        }
        
    }

    public void BackToStageUi()
    {
        stageUi.SetActive(true);
        loadOutUi.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu_UIScenes");
    }
}
