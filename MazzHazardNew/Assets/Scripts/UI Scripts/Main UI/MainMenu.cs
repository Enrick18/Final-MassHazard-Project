using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void LoadStage()
   {
      SceneManager.LoadScene("StagesUI_Scene");
   }

   public void LoadLevelEditor()
   {
      SceneManager.LoadScene("LevelEditor");
   }

   public void BackToMenu()
   {
      SceneManager.LoadScene("MainMenu_UIScenes");
   }
   public void QuitApplication()
    {
        Application.Quit();
    }
}
