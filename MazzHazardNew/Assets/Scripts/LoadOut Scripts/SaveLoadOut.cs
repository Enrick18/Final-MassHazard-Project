using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadOut : MonoBehaviour
{
    public LoadOutHeroList playerLoadOut;
    public Sprite activatedImage;
    public Sprite originalImage;
    private Button button;
    public string levelKey;
    public int levelUnlocked;
    [SerializeField]private bool isLevelEditor = false;
    
    private void Start() 
    {
        levelUnlocked = PlayerPrefs.GetInt(levelKey, 0);
        button = GetComponent<Button>();
        button.image.sprite = originalImage;

        if (isLevelEditor) 
        {
            levelUnlocked = 1;
        }

        if (levelUnlocked != 0)
        {
            button.interactable = true;
        }
        else 
        { 
            button.interactable=false;
        }
    }
    public void HeroSelected(int index)
    {
        for(int i = 0; i < playerLoadOut.heroChoosenIndex.Count; i++)
        {
            if(playerLoadOut.heroChoosenIndex[i] == index)
            {
                playerLoadOut.heroChoosenIndex[i] = -1;
                button.image.sprite = originalImage;
                return;
            }
        }

        for(int i = 0; i < playerLoadOut.heroChoosenIndex.Count; i++)
        {
            if(playerLoadOut.heroChoosenIndex[i] == -1)
            {
                playerLoadOut.heroChoosenIndex[i] = index;
                button.image.sprite = activatedImage;
                break;
            }
        }

    }
}
