using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroButton : MonoBehaviour
{
    public bool isMeleeHeroType;
    public GameObject heroModel;
    public int setHeroCost;

    private TowerManager towerManager;
    private HeroSelected isMeleeSelected;
    private CurrencySystem currencySystem;

    private GameObject heroSelected;

    public Button heroButton;

    // Start is called before the first frame update
    void Start()
    {
        heroSelected = GameObject.Find("Hero Selection"); //find the Ui called HeroSelection

        towerManager = heroSelected.GetComponent<TowerManager>(); //get towermanager script
        isMeleeSelected = heroSelected.GetComponent<HeroSelected>(); //get heroselected script
        currencySystem = heroSelected.GetComponent<CurrencySystem>();//get currency script
    }

    private void Update()
    {
        if (currencySystem.currentCurrency < setHeroCost)
        {
            heroButton.interactable = false;
        }
        else 
        { 
            heroButton.interactable=true;
        }
    }

    //assign designated values to the functions
    public void IsMeleeHeroType()
    {
        isMeleeSelected.OnMeleeHeroSelected(isMeleeHeroType);
    }

    public void SetTowerModel()
    {
        towerManager.GetTowerReference(heroModel);
    }

    public void PassTowerCost()
    {
        towerManager.SetTowerCost(setHeroCost);
    }

}
