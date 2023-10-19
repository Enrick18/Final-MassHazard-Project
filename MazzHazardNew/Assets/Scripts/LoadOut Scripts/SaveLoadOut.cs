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
    
    private void Start() 
    {
         button = GetComponent<Button>();
         button.image.sprite = originalImage;
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
