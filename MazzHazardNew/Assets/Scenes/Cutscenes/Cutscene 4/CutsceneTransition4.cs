using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController4 : MonoBehaviour
{
    // Assign your video player or cutscene object to this variable
    public GameObject cutsceneObject;

    // Name of the next scene to load after the cutscene
    public string nextSceneName;

    // Update is called once per frame
    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the cutscene is active
            if (cutsceneObject.activeSelf)
            {
                // Skip the cutscene and load the next scene
                LoadNextScene();
            }
        }
    }

    void LoadNextScene()
    {
        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}