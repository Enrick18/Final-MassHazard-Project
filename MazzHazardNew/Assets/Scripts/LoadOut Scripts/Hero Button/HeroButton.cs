using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroButton : MonoBehaviour
{
    public bool isMeleeHeroType;
    public GameObject heroModel;
    public int setHeroCost;

    private TowerManager towerManager;
    private HeroSelected isMeleeSelected;

    private GameObject heroSelected;

    // Start is called before the first frame update
    void Start()
    {
        heroSelected = GameObject.Find("Hero Selection"); //find the Ui called HeroSelection

        towerManager = heroSelected.GetComponent<TowerManager>(); //get towermanager script
        isMeleeSelected = heroSelected.GetComponent<HeroSelected>(); //get heroselected script     
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
