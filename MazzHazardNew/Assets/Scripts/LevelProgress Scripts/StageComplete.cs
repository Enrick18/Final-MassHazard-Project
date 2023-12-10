using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageComplete : MonoBehaviour
{
    public string unlockNextDifficulty;
    public string unlockNextStage;

    public string unlockStar;

    public void SaveProgress()
    {
        PlayerPrefs.SetInt(unlockStar, 1);

        if (unlockNextDifficulty != null) 
        {
            PlayerPrefs.SetInt(unlockNextDifficulty, 1);
        }

        if (unlockNextStage != null)
        {
            PlayerPrefs.SetInt(unlockNextStage, 1);
        }
    }
}
