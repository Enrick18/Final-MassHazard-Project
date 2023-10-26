using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionMenu : MonoBehaviour
{
    
    [HideInInspector] public GameObject selectedCube;
    [HideInInspector] public GameObject selectedChildCube;

    private Button goal;
    private Button spawner;

    private bool isGoalSelected = false;
    private bool isSpawnerSelected = false;
    private List<GameObject> buttonList = new();
    private GameObject removeButton;

    private void Start()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            var child = transform.GetChild(i).gameObject;
            buttonList.Add(child);

            if(i == 0)
            {
                spawner = child.GetComponent<Button>();
            }

            if (i == 1)
            {
                goal = child.GetComponent<Button>();
            }

        }
        removeButton = transform.GetChild(transform.childCount - 1).gameObject;
    }

    private void Update()
    {
        if(isSpawnerSelected) 
        { 
            spawner.interactable = false;
        }
        else
        {
            spawner.interactable = true;
        }
        if(isGoalSelected)
        {
            goal.interactable = false;
        }
        else
        {
            goal.interactable = true;
        }
    }

    public void EnableButtons()
    {
        foreach (var button in buttonList)
        {
            button.SetActive(true);
        }
    }

    public void DisableButtons()
    {
        foreach(var button in buttonList)
        {
            button.SetActive(false);
        }
    }
    public void EnableRemoveButton()
    {
        removeButton.SetActive(true);
    }
    public void DisableRemoveButton()
    {
        removeButton.SetActive(false);
    }

    public void EnableTile(int index)
    {
        selectedCube.transform.GetChild(index).gameObject.SetActive(true);
        DisableButtons();

        if(index == 0)
        {
            isSpawnerSelected = true;
        }

        if(index == 1)
        {
            isGoalSelected = true;
        }
    }
    

    public void DisableTile()
    {
        if (selectedChildCube.transform.parent.tag == "Cube")
        {
           int index = selectedChildCube.transform.GetSiblingIndex();

            if (index == 0)
            {
                isSpawnerSelected = false;
            }

            else if (index == 1)
            {
                isGoalSelected = false;
            }
            selectedChildCube.SetActive(false);
        }
        else if(selectedChildCube.transform.parent.tag == "ChildCube")
        {

            int index = selectedChildCube.transform.parent.GetSiblingIndex();

            if (index == 0)
            {
                isSpawnerSelected = false;
            }

            else if (index == 1)
            {
                isGoalSelected = false;
            }
            selectedChildCube.transform.parent.gameObject.SetActive(false);
        }
        DisableRemoveButton();
    }   
}
