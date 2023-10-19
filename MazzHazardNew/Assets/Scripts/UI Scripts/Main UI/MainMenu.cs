using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void LoadStage()
   {
      SceneManager.LoadScene("StageScene");
   }

   public void LoadLevelEditor()
   {
      SceneManager.LoadScene("LevelEditor");
   }

   public void LoadSettings()
   {
      SceneManager.LoadScene("Settings");
   }

   public void BackToMenu()
   {
      SceneManager.LoadScene("MainMenu");
   }
   public void LoadCharacterCards()
   {
      SceneManager.LoadScene("CharacterCards");
   }
   public void QuitApplication()
    {
        Application.Quit();
    }
}
