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
    [SerializeField]private bool loadOutChecker = false;

    public void SetLevelToLoad(string level)
    {
        stageUi.SetActive(false);
        loadOutUi.SetActive(true);
        MissionSelect.levelToLoad = level;

    }

    public void LoadLevel()
    {
        for (int i = 0; i < heroList.heroChoosenIndex.Count; i++)
        {
            if (heroList.heroChoosenIndex[i] != -1)
            {
                loadOutChecker = true;
            }
        }

        if (loadOutChecker)
        {
            if (MissionSelect.levelToLoad == "EasyLevel01")
            {
                PlayCutscene01();
            }

            else if (MissionSelect.levelToLoad == "EasyLevel02")
            {
                PlayCutscene02();
            }

            else if (MissionSelect.levelToLoad == "EasyLevel05")
            {
                PlayCutscene05();
            }

            else if (MissionSelect.levelToLoad == "EasyLevel10")
            {
                PlayCutscene03();
            }

            else
                SceneManager.LoadScene(MissionSelect.levelToLoad);
        }
        else
        {
            warningUi.SetActive(true);
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

    public void PlayCutscene01()
    {
        SceneManager.LoadScene("Cutscene1");
    }
    public void PlayCutscene02()
    {
        SceneManager.LoadScene("Cutscene2");
    }
    public void PlayCutscene03()
    {
        SceneManager.LoadScene("Cutscene3");
    }
    public void PlayCutscene04()
    {
        SceneManager.LoadScene("Cutscene4");
    }
    public void PlayCutscene05()
    {
        SceneManager.LoadScene("Cutscene5");
    }

}
