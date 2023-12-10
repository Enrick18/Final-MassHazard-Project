using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelEditor : MonoBehaviour
{
    public string gameModeSelected;
    public int[] enemyWaveIndex = { -1, -1, -1, -1, -1 };
    public int[] numberOfEnemies = { 0, 0, 0, 0, 0 };
    public int waveCount = 1;
    public int hpCount = 1;
    public int capsuleCount = 30;
    public string finalMapName = "New Map";
    public bool isRogue = false;

    public GameObject waveSettingScene;
    public GameObject gameModeScene;
    public Text waveText;
    public Text hpText;
    public Text capsuleText;
    public List<Text> enemyCountText;
    public TMP_InputField mapNameInputField;
    public WaveManager waveManager;


    public void GameModeSelected(string mode)
    {
        gameModeSelected = mode;
        if (mode == "Rogue")
        {
            isRogue = true;
            waveCount = Random.Range(3, 5);
            hpCount = Random.Range(5, 10);
            capsuleCount = Random.Range(30, 70);
            
            for (int i = 0; i < waveCount; i++)
            {
                numberOfEnemies[i] = Random.Range(1, 12);
                enemyWaveIndex[i] = Random.Range(0, 5);
            }
        }

    }

    public void HpBack()
    {
        waveManager.waveIndex = 0;
    }

    public void IncrementWave() //add Waves
    {
        if (waveCount < 5)
            waveCount++;

        waveText.text = waveCount.ToString();
    }

    public void DecrementWave() //deacrease Waves
    {
        if (waveCount > 1)
            waveCount--;

        waveText.text = waveCount.ToString();
    }

    public void EnemySelectedWave(int index) //Assign Enemies for each wave
    {
        enemyWaveIndex[waveManager.waveIndex - 1] = index;
        numberOfEnemies[waveManager.waveIndex - 1] = 1;
    }

    public void IncrementEnemies() //Increment number of enemies
    {
        if (numberOfEnemies[waveManager.waveIndex - 1] < 12)
            numberOfEnemies[waveManager.waveIndex - 1]++;

        enemyCountText[waveManager.waveIndex - 1].text = numberOfEnemies[waveManager.waveIndex - 1].ToString();
    }

    public void DecrementEnemies() //Decrement number of enemies
    {
        if (numberOfEnemies[waveManager.waveIndex - 1] > 1)
            numberOfEnemies[waveManager.waveIndex - 1]--;

        enemyCountText[waveManager.waveIndex - 1].text = numberOfEnemies[waveManager.waveIndex - 1].ToString();
    }


    public void IncrementHp() //Increment Hp Count
    {
        if (hpCount < 10)
            hpCount++;

        hpText.text = hpCount.ToString();
    }

    public void DecrementHp() //Decrement Hp Count
    {
        if (hpCount > 1)
            hpCount--;

        hpText.text = hpCount.ToString();
    }

    public void IncrementCapsule() //Increment Starting Capsule minimum of 30 max of 70
    {
        if (capsuleCount < 70)
            capsuleCount += 10;

        capsuleText.text = capsuleCount.ToString();
    }

    public void DecrementCapsule() //Decrement Starting Capsule minimum of 30 max of 70
    {
        if (capsuleCount > 30)
            capsuleCount -= 10;

        capsuleText.text = capsuleCount.ToString();
    }

    public void SetMapName() // Set the  Map Name
    {
        if (mapNameInputField.text != "") 
        {
            finalMapName = mapNameInputField.text;
        }
        
    }

    public void MapNameBack()
    {
        if (isRogue)
            gameModeScene.SetActive(true);
        else
            waveSettingScene.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu_UIScenes");
    }

}
