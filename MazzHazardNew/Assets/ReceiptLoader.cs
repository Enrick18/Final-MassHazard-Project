using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReceiptLoader : MonoBehaviour
{
    public Image imageReceipt;
    public Transform parent;
    public LevelEditor levelEditor;
    public ListOfSpites sprites;

    private void OnEnable()
    {
        WaveManager.OnReceiptLoad += GenerateReceipt;
    }

    private void OnDisable()
    {
        WaveManager.OnReceiptLoad -= GenerateReceipt;
    }

    public void GenerateReceipt() 
    {
        if (parent.childCount > 0) 
        {
            for (int i = 0; i < parent.childCount; i++) 
            { 
                Destroy(parent.GetChild(i).gameObject);
            }
        }


        for (int i = 0; i < levelEditor.waveCount; i++) 
        {
            int x = i + 1;
            Image image = Instantiate(imageReceipt, parent);

            TextMeshProUGUI wave = image.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI mobName = image.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            image.sprite = sprites.enemyImages[levelEditor.enemyWaveIndex[i]];

            wave.text = "Wave: " + x.ToString();
            mobName.text = sprites.enemyNames[levelEditor.enemyWaveIndex[i]]+": "+ levelEditor.numberOfEnemies[i].ToString();
        }
    }
}
