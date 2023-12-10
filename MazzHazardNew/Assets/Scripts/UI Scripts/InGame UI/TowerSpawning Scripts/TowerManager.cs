using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerManager : MonoBehaviour
{
    private int currentTowerCost;
    private GameObject towerPrefab;

    private CurrencySystem currency;

    private Transform towerPosition;
    private TowerPlacement placement;

    [SerializeField] private GameObject directionCanvas;

    private bool isSelected = false;

    private GameObject tile = null;
    [Range(1,2)]
    public float healthElementalMultiplier = 1f;
    [Range(1,2)]
    public float damageElementalMultiplier = 1f;

    private void Awake()
    {
        currency = GetComponent<CurrencySystem>();
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && towerPrefab != null && !isSelected)
        {
            tile = null;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.gameObject.tag == "Tile")
                {
                    tile = hit.collider.gameObject;
                    towerPosition = tile.transform.GetChild(0);
                    placement = tile.GetComponent<TowerPlacement>();

                    if (tile != null)
                    {

                        if (towerPrefab.GetComponent<HeroController>() != null && placement.isMeleeBlock && !placement.hasTower)
                        {
                            if (currency.EnoughCurrency(currentTowerCost))
                            {
                                placement.hasTower = true;
                                isSelected = true;
                                SpawnTower();
                            }

                        }
                        else if ((towerPrefab.GetComponent<HeroRangeTower>() != null || towerPrefab.GetComponent<HealerTower>() != null) && !placement.isMeleeBlock && !placement.hasTower)
                        {
                            if (currency.EnoughCurrency(currentTowerCost))
                            {
                                placement.hasTower = true;
                                isSelected = true;
                                SpawnTower();
                            }

                        }


                    }
                }
                else 
                {
                    towerPrefab = null;
                }
            }
        }

        if (towerPrefab == null && isSelected)
        {
            isSelected = false;
        }
    }
    public void GetTowerReference(GameObject tower)
    {
        towerPrefab = tower;
    }

    public void SetTowerCost(int towerCost)
    {
        currentTowerCost = towerCost;
    }

    public void OrientTower(float yRotation)
    {
        // Debug.Log(yRotation);
        TileBuff buff = null;
        IHealthSystem health = null;
        IHeroStats heroStats = null;

        
        Quaternion rot = new Quaternion();
        Debug.Log(towerPosition);
       
        rot.eulerAngles = new Vector3(towerPosition.rotation.x, yRotation, towerPosition.rotation.z);
        
        
        var tower = Instantiate(towerPrefab, towerPosition.position, rot);

        health = tower.GetComponent<IHealthSystem>();
        heroStats = tower.GetComponent<IHeroStats>();
        buff = tile.GetComponent<TileBuff>();

        if (buff != null) // computation if there is a tile buff
        {
            if(buff.tileElement == health.GetElementType())
            {
                health.ApplyElementalEffect(healthElementalMultiplier);
                heroStats.ModifyHeroDamage(damageElementalMultiplier);
            }
            else if((buff.tileElement != health.GetElementType()) && health.GetElementType() != ElementType.Normal)
            {
                //health.ApplyElementalEffect(1f-(healthElementalMultiplier%1));
                heroStats.ModifyHeroDamage(0.75f);
            }
        }
        placement.hasTower = true;

        currency.UseCurrency(currentTowerCost);

        isSelected = false;

        directionCanvas.SetActive(false);
        towerPrefab = null;
        towerPosition = null;

        placement.hasTower = false;

        tile = null;

    }
    public void SpawnTower()
    {

        placement.hasTower = true;
        Debug.Log(placement.hasTower);
        // Debug.Log(yRotation);
        TileBuff buff = null;
        IHealthSystem health = null;
        IHeroStats heroStats = null;

        var tower = Instantiate(towerPrefab, tile.transform.GetChild(0).position, tile.transform.GetChild(0).rotation);

        health = tower.GetComponent<IHealthSystem>();
        heroStats = tower.GetComponent<IHeroStats>();
        buff = tile.GetComponent<TileBuff>();

        if (buff != null) // computation if there is a tile buff
        {
            if (buff.tileElement == health.GetElementType())
            {
                health.ApplyElementalEffect(healthElementalMultiplier);
                heroStats.ModifyHeroDamage(damageElementalMultiplier);
            }
            else if ((buff.tileElement != health.GetElementType()) && health.GetElementType() != ElementType.Normal)
            {
                //health.ApplyElementalEffect(1f-(healthElementalMultiplier%1));
                heroStats.ModifyHeroDamage(0.85f);
            }
        }
        currency.UseCurrency(currentTowerCost);

        isSelected = false;

        directionCanvas.SetActive(false);
        towerPrefab = null;
        towerPosition = null;

        placement.hasTower = false;

        tile = null;

    }
}
