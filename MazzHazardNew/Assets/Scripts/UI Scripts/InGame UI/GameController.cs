using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public CutsceneTransition hasPlayedCutscene;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void StopPlayingCutscene()
    {
        int cutscenePlayer = PlayerPrefs.GetInt("asPlayedCutscene", hasPlayedCutscene ? 1 : 1);
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
        SceneManager.LoadScene("StagesUI_Scene");
    }

    public void ToLevelEditor()
    {
        SceneManager.LoadScene("LevelEditor");
    }
    

}
