using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public TextMeshProUGUI fileName;
    public MapSceneToLoad button;
    public Sprite[] mapSprites;

    private void Start() {

        var getImage = button.GetComponent<Image>();
        
        if(button.mapName == "Map01")
        {
            getImage.sprite = mapSprites[0];
        }
        else if(button.mapName == "Map02")
        {
            getImage.sprite = mapSprites[1];
        }
        else
        {
            getImage.sprite = mapSprites[2];
        }

        fileName.text = button.fileName.ToString();
    }
}
