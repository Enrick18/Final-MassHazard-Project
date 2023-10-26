using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCustomScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
   
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
