using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverViewScript : MonoBehaviour
{
    public List<Sprite> easyMapImages = new List<Sprite>();
    public List<Sprite> mediumMapImages = new List<Sprite>();
    public List<Sprite> hardMapImages = new List<Sprite>();

    public List<GameObject> enemyInfo = new List<GameObject>();

    public Transform parent;
    public Image displayMap;


    public void EnemyOverview()
    {
        if (MissionSelect.levelToLoad == "EasyLevel01")
        {
            displayMap.sprite = easyMapImages[0];
            Instantiate(enemyInfo[0], parent);
        }
        else if (MissionSelect.levelToLoad == "EasyLevel02")
        {
            displayMap.sprite = easyMapImages[1];
            Instantiate(enemyInfo[0], parent);

        }
        else if (MissionSelect.levelToLoad == "EasyLevel03")
        {
            displayMap.sprite = easyMapImages[2];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[2], parent);
        }
        else if (MissionSelect.levelToLoad == "EasyLevel04")
        {
            displayMap.sprite = easyMapImages[3];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
        }
        else if (MissionSelect.levelToLoad == "EasyLevel05")
        {
            displayMap.sprite = easyMapImages[4];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);

        }
        else if (MissionSelect.levelToLoad == "EasyLevel06")
        {
            displayMap.sprite = easyMapImages[5];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[4], parent);
        }
        else if (MissionSelect.levelToLoad == "EasyLevel07")
        {
            displayMap.sprite = easyMapImages[6];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
        }
        else if (MissionSelect.levelToLoad == "EasyLevel08")
        {
            displayMap.sprite = easyMapImages[7];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[4], parent);
            Instantiate(enemyInfo[5], parent);
        }
        else if (MissionSelect.levelToLoad == "EasyLevel09")
        {
            displayMap.sprite = easyMapImages[8];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[5], parent);
        }
        else if (MissionSelect.levelToLoad == "EasyLevel10")
        {
            displayMap.sprite = easyMapImages[9];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[4], parent);
            Instantiate(enemyInfo[5], parent);
        }
        else if (MissionSelect.levelToLoad == "MediumLevel01")
        {
            displayMap.sprite = mediumMapImages[0];
            Instantiate(enemyInfo[0], parent);

        }
        else if (MissionSelect.levelToLoad == "MediumLevel02")
        {
            displayMap.sprite = mediumMapImages[1];
            Instantiate(enemyInfo[0], parent);

        }
        else if (MissionSelect.levelToLoad == "MediumLevel03")
        {
            displayMap.sprite = mediumMapImages[2];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[2], parent);
        }
        else if (MissionSelect.levelToLoad == "MediumLevel04")
        {
            displayMap.sprite = mediumMapImages[3];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
        }
        else if (MissionSelect.levelToLoad == "MediumLevel05")
        {
            displayMap.sprite = mediumMapImages[4];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
        }
        else if (MissionSelect.levelToLoad == "MediumLevel06")
        {
            displayMap.sprite = mediumMapImages[5];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[4], parent);
        }
        else if (MissionSelect.levelToLoad == "MediumLevel07")
        {
            displayMap.sprite = mediumMapImages[6];
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[4], parent);
        }
        else if (MissionSelect.levelToLoad == "MediumLevel08")
        {
            displayMap.sprite = mediumMapImages[7];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[5], parent);
        }
        else if (MissionSelect.levelToLoad == "MediumLevel09")
        {
            displayMap.sprite = mediumMapImages[8];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[5], parent);
        }
        else if (MissionSelect.levelToLoad == "MediumLevel10")
        {
            displayMap.sprite = mediumMapImages[9];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[4], parent);
            Instantiate(enemyInfo[5], parent);

        }
        else if (MissionSelect.levelToLoad == "HardLevel01")
        {
            displayMap.sprite = hardMapImages[0];
            Instantiate(enemyInfo[0], parent);

        }
        else if (MissionSelect.levelToLoad == "HardLevel02")
        {
            displayMap.sprite = hardMapImages[1];
            Instantiate(enemyInfo[0], parent);

        }
        else if (MissionSelect.levelToLoad == "HardLevel03")
        {
            displayMap.sprite = hardMapImages[2];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[2], parent);
        }
        else if (MissionSelect.levelToLoad == "HardLevel04")
        {
            displayMap.sprite = hardMapImages[3];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
        }
        else if (MissionSelect.levelToLoad == "HardLevel05")
        {
            displayMap.sprite = hardMapImages[4];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
        }
        else if (MissionSelect.levelToLoad == "HardLevel06")
        {
            displayMap.sprite = hardMapImages[5];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[4], parent);
        }
        else if (MissionSelect.levelToLoad == "HardLevel07")
        {
            displayMap.sprite = hardMapImages[6];
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[4], parent);
        }
        else if (MissionSelect.levelToLoad == "HardLevel08")
        {
            displayMap.sprite = hardMapImages[7];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[5], parent);

        }
        else if (MissionSelect.levelToLoad == "HardLevel09")
        {
            displayMap.sprite = hardMapImages[8];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[5], parent);
        }
        else if (MissionSelect.levelToLoad == "HardLevel10")
        {
            displayMap.sprite = hardMapImages[9];
            Instantiate(enemyInfo[0], parent);
            Instantiate(enemyInfo[1], parent);
            Instantiate(enemyInfo[2], parent);
            Instantiate(enemyInfo[3], parent);
            Instantiate(enemyInfo[5], parent);

        }
    }

    public void DestroyEnemyInfo() 
    {
        if (parent.childCount > 0)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Destroy(parent.GetChild(i).gameObject);
            }
        }
    }

}
