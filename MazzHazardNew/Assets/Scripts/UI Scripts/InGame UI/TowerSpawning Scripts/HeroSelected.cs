using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelected : MonoBehaviour
{
    //Code for Finding the Tiles able to spawned on
    public TowerPlacement[] heroTiles;
    private List<Color> heroTileColors = new List<Color>();
    private bool isTowerSelected = false;

    //models for instantiation

    public void OnMeleeHeroSelected(bool isMeleeHero)
    {
        isTowerSelected = true;

        foreach(var tiles in heroTiles)
        {
            heroTileColors.Add(tiles.GetComponentInChildren<MeshRenderer>().material.color);
            //Call the change color function
            if(isMeleeHero == tiles.GetComponent<TowerPlacement>().isMeleeBlock)
            {
                MeshRenderer meshRenderer = tiles.GetComponentInChildren<MeshRenderer>();
                // Debug.Log(tiles.gameObject);
                Material material = meshRenderer.material;
                material.color = Color.yellow;
            }
        
        }
    }
    

    private void Start() 
    {
        heroTiles = FindObjectsOfType<TowerPlacement>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            if(isTowerSelected)
            {
                isTowerSelected = false;
                for(int i = 0; i < heroTiles.Length; i++)
                {
                    MeshRenderer meshRenderer = heroTiles[i].GetComponentInChildren<MeshRenderer>();
                    Material material = meshRenderer.material;
                    material.color = heroTileColors[i];

                }
            }
        }
    }
}
