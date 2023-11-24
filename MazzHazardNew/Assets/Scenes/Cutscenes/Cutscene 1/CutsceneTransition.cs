using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTransition : MonoBehaviour
{
    private bool hasPlayedCutscene = false;
    public string nextSceneName = "EasyLevel01"; // Change this to the name of your gameplay scene

    void Start()
    {
        // Check if the cutscene has already been played
        if (!hasPlayedCutscene)
        {
            // Play the cutscene
            // Add your code here to play the cutscene, e.g., using VideoPlayer component

            // Set the flag to true to indicate that the cutscene has been played
            hasPlayedCutscene = true;

            // Save the flag to PlayerPrefs
            PlayerPrefs.SetInt("HasPlayedCutscene", hasPlayedCutscene ? 1 : 0);
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
        SceneManager.LoadScene(nextSceneName);
    }
}

