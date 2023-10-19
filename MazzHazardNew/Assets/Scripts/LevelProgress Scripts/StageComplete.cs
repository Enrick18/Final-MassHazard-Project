using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageComplete : MonoBehaviour
{
    public string unlockNextDifficulty;
    public string unlockNextStage;

    public void SaveProgress()
    {

        PlayerPrefs.SetInt(unlockNextDifficulty, 1);

        if (unlockNextStage != null)
        {
            PlayerPrefs.SetInt(unlockNextStage, 1);
        }
    }
}
