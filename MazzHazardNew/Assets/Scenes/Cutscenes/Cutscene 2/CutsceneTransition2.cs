
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTransition2 : MonoBehaviour
{
    private bool hasPlayedCutscene2 = false;
    public string nextSceneName2 = "StagesUI_Scene"; // Change this to the name of your gameplay scene

    void Start()
    {
        // Check if the cutscene has already been played
        if (!hasPlayedCutscene2)
        {
            // Play the cutscene
            // Add your code here to play the cutscene, e.g., using VideoPlayer component

            // Set the flag to true to indicate that the cutscene has been played
            hasPlayedCutscene2 = true;

            // Save the flag to PlayerPrefs
            PlayerPrefs.SetInt("HasPlayedCutscene", hasPlayedCutscene2 ? 1 : 0);
            PlayerPrefs.Save();
        }
        else
        {
            // Cutscene has already been played, load the gameplay scene directly
            LoadGameplayScene();
        }
    }

    private void LoadGameplayScene()
    {
        // Load the next scene (gameplay scene)
        SceneManager.LoadScene(nextSceneName2);
    }
}

