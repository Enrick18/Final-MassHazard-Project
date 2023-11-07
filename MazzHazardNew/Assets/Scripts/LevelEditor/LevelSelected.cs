using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;



public class LevelSelected : MonoBehaviour
{
    [SerializeField] private MapData mapDataSO;
    private string levelName = "";
    private TextMeshProUGUI textName;

    private void Start()
    {
        textName = GetComponentInChildren<TextMeshProUGUI>();
        levelName = textName.text;
    }
    public void SelectedLevel()
    {
        mapDataSO.mapName = levelName; 
    }

    
}
