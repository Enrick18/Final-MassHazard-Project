using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isLevelEditor = false;

    // Start is called before the first frame update
    void Awake()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        if (!isLevelEditor)
        {
            SceneManager.LoadScene("StagesUI_Scene");
        }
        else if(isLevelEditor == true)
        {
            Debug.Log("LevelEditor");
            SceneManager.LoadScene("LevelEditor");
        }
    }

    public void ToLevelEditor()
    {
        SceneManager.LoadScene("LevelEditor");
    }

    public void EndCutscene(bool isLevel10) 
    {
        if (isLevel10) 
        {
            SceneManager.LoadScene("Cutscene4");
        }
    }
}
