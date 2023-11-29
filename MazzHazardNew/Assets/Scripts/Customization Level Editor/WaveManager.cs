using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> waveScreens = new List<GameObject>();
    public GameObject nextScreen;
    public GameObject prevScreen;
    public LevelEditor levelEditor;
    public int waveIndex = 0;
    public static event Action OnReceiptLoad;
    
    public void Temp()
    {
        waveScreens[3].gameObject.SetActive(true);
    }

    public void WaveCounter()
    {
        if (waveIndex > levelEditor.waveCount - 1) 
        {
            nextScreen.gameObject.SetActive(true);
            OnReceiptLoad?.Invoke();
        }


        for (int i = 0; i <= levelEditor.waveCount-1; i++)
        {
            if (i == waveIndex)
            {
                waveScreens[i].gameObject.SetActive(true);
            }
            else
            {
                waveScreens[i].gameObject.SetActive(false);
            }
        }
        waveIndex++;
    }
    
    public void DecrementWave()
    {
        waveIndex--;
        Debug.Log(waveIndex);
        if(waveIndex == 1)
        {   
            prevScreen.gameObject.SetActive(true);
        }
            

        for (int i = 0; i < levelEditor.waveCount; i++)
        {
            if (i == waveIndex-1)
            {
                waveScreens[i].gameObject.SetActive(true);
            }
            else
            {
                waveScreens[i].gameObject.SetActive(false);
            }

        }
    }

}
