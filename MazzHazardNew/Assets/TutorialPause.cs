using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPause : MonoBehaviour
{
    public GameObject getEssentials;
    public GameObject tutorial;
    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(false);
        Invoke(nameof(TimeStop), 2f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TimeStop() 
    {
        getEssentials.SetActive(false);
        tutorial.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TimeResume() 
    {
        Time.timeScale = 1f;
        getEssentials.SetActive(true);
    }
}
