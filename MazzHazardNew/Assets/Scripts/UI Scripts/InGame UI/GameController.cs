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
        Debug.Log(isLevelEditor);
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
        Debug.Log("Checker is " +isLevelEditor);

        if (!isLevelEditor)
        {
            Debug.Log("StagesUI");
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
}
