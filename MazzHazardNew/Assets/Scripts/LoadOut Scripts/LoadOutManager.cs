using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadOutManager : MonoBehaviour
{
    public HeroDatabase database;
    public LoadOutHeroList heroList;
    public Transform parent;
    private List<GameObject> characterCards = new List<GameObject>();
    
    private void OnEnable()
    {
        for (int i = 0; i < heroList.heroChoosenIndex.Count; i++ ) 
        { 
            heroList.heroChoosenIndex[i] = -1;
        }
       
        InstantiateHeroButtons();
    }

    private void OnDisable() {
        DestroyHeroButtons();
    }

    public void InstantiateHeroButtons()
    {
        for (int j = 0; j < database.heroLists.Count; j++)
        {
            var card = Instantiate(database.heroLists[j].characterCard,parent);
            int isCardEnabled = card.GetComponent<SaveLoadOut>().levelUnlocked;
            Debug.Log(isCardEnabled);

            if (isCardEnabled != 0)
            {
                card.GetComponent<Button>().interactable = true;
            }
            else 
            { 
                card.GetComponent <Button>().interactable = false;
            }
            
            characterCards.Add(card);
        }

    }

    public void DestroyHeroButtons()
    {
        foreach(var card in characterCards)
        {
            Destroy(card);
        }
    }
}
