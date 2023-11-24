
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTransition3 : MonoBehaviour
{
    private bool hasPlayedCutscene3 = false;
    public string nextSceneName3 = "EasyLevel10"; // Change this to the name of your gameplay scene

    void Start()
    {
        // Check if the cutscene has already been played
        if (!hasPlayedCutscene3)
        {
            // Play the cutscene
            // Add your code here to play the cutscene, e.g., using VideoPlayer component

            // Set the flag to true to indicate that the cutscene has been played
            hasPlayedCutscene3 = true;

            // Save the flag to PlayerPrefs
            PlayerPrefs.SetInt("HasPlayedCutscene", hasPlayedCutscene3 ? 1 : 0);
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
        SceneManager.LoadScene(nextSceneName3);
    }
}

