using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadOutSelectedHeroes : MonoBehaviour
{
    public HeroDatabase database;
    public LoadOutHeroList heroIndex;
    public GameObject parentObject;
    void Start()
    {
        for (int i = 0; i < heroIndex.heroChoosenIndex.Count; i++)
        {
            if (i == -1)
            {
                break;
            }

            for (int j = 0; j < database.heroLists.Count; j++)
            {
                if (database.heroLists[j].heroIndex == heroIndex.heroChoosenIndex[i])
                {
                    GameObject button = Instantiate(database.heroLists[heroIndex.heroChoosenIndex[i]].buttonPrefab, parentObject.transform);
                }
            }


        }

    }

}
