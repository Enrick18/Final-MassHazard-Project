using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPause : MonoBehaviour
{
    private bool tutorialDone = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialDone) 
        {
            Time.timeScale = 1f;
        }
        else 
        {
            Time.timeScale = 0f;
        }
    }

    public void TimeResume() 
    {
        Time.timeScale = 1f;
        tutorialDone = true;
    }
}
