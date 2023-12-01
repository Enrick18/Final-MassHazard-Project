using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockEnabler : MonoBehaviour
{
    private int tileIndex = -1;
    private bool isRemove = false;
    private bool isSpawner = false;
    private bool isGoal = false;
    public GameObject cancelButton;
    public Button spawnButton;
    public Button goalButton;


    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            GameObject clickedObject = null;
            GameObject clickedChildObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Perform the raycast to detect the clicked object
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the collider hit belongs to a clickable object

                if (hit.collider.gameObject.tag == "Cube")
                {
                    clickedObject = hit.collider.gameObject;
                }

                if (hit.collider.gameObject.tag == "ChildCube")
                {
                    clickedChildObject = hit.collider.gameObject;
                }

                if (clickedObject != null && tileIndex != -1 && !isRemove) 
                {
                    if (tileIndex == 0)
                    {
                        isSpawner = true;
                        spawnButton.interactable = false;
                        tileIndex = -1;
                    }
                    else if (tileIndex == 1) 
                    {
                        isGoal = true;
                        goalButton.interactable = false;
                        tileIndex -= -1;
                    }

                    clickedObject.transform.GetChild(tileIndex).gameObject.SetActive(true);
                }

                if (clickedChildObject != null && isRemove) 
                { 
                    clickedChildObject.transform.gameObject.SetActive(false);
                }

            }
        }
    }

    public void OnSpawnerClicked(int index) 
    {
        tileIndex = index; 
        isRemove = false;
        cancelButton.SetActive(true);
    }

    public void OnGoalClicked(int index) 
    {
        tileIndex = index;
        isRemove = false;
        cancelButton.SetActive(true);

    }

    public void OnPathClicked(int index) 
    {
        tileIndex = index;
        isRemove = false;
        cancelButton.SetActive(true);

    }

    public void OnRangeClicked(int index) 
    {
        tileIndex = index;
        isRemove = false;
        cancelButton.SetActive(true);

    }

    public void OnTressClicked(int index) 
    {
        tileIndex = index;
        isRemove = false;
        cancelButton.SetActive(true);

    }

    public void OnGrassClicked(int index) 
    {
        tileIndex = index;
        isRemove = false;
        cancelButton.SetActive(true);

    }

    public void OnRemoveClicked() 
    { 
        isRemove = true;
        cancelButton.SetActive(true);
        tileIndex = -1;
    }

    public void OnCancelClicked() 
    { 
        cancelButton.SetActive(false);
        isRemove = false;
        tileIndex = -1;
    }
}


