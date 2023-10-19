using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUnlock : MonoBehaviour
{
    public string levelKey;
    public Button button;

    private void Start() 
    {  
        int level = PlayerPrefs.GetInt(levelKey, 0);

        if(level != 0)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }   
    }
}
