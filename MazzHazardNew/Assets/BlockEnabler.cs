using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class BlockEnabler : MonoBehaviour
{
    private int tileIndex = -1;
    private bool isRemove = false;
    private bool isSpawner = false;
    private bool isGoal = false;
    public GameObject cancelButton;
    public Button spawnButton;
    public Button goalButton;
    public Button pathButton;

    public CheckPath checkPath;

    [SerializeField]private NavMeshSurface navMeshSurface;
    private Transform spawner; // Spawner point
    private Transform goal; // End point
    public GameObject validMapMessage;
    public GameObject invalidMapMessage;

    public Button confirmButton;

    private bool pathComplete = false;
    //public static event Action OnLayoutChanged;


    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            //OnLayoutChanged?.Invoke();

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

                if (pathComplete && tileIndex == 4) 
                {
                    tileIndex = -1;
                }

                if (clickedObject != null && tileIndex != -1 && !isRemove) 
                {
                    if (tileIndex != 0 || !isSpawner) 
                    {
                        if(tileIndex != 1 || !isGoal)
                        clickedObject.transform.GetChild(tileIndex).gameObject.SetActive(true);

                    }

                    SpawnerCheck();
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
                        tileIndex = -1;
                    }
                }

                if (clickedChildObject != null && isRemove) 
                { 
                    int index = clickedChildObject.transform.GetSiblingIndex();
                    if (index == 0)
                    {
                        isSpawner = false;
                        spawnButton.interactable = true;
                    }
                    else if (index == 1) 
                    {
                        isGoal = false;
                        goalButton.interactable = true;
                    }


                    clickedChildObject.transform.gameObject.SetActive(false);
                    SpawnerCheck();

                }

            }
        }
    }

    public void SpawnerCheck() 
    {

        navMeshSurface.RemoveData();
        navMeshSurface.BuildNavMesh();

        try
        {            
            spawner = GameObject.Find("Spawner").transform.GetChild(0);
            goal = GameObject.Find("Goal").transform.GetChild(2);
        }
        catch
        {
            invalidMapMessage.SetActive(true);
            confirmButton.interactable = false;
        }

        NavMeshCheck();

    }

    public void NavMeshCheck() 
    {
        if (spawner != null && goal != null)
        {
            NavMeshPath path = new NavMeshPath();

            if (NavMesh.CalculatePath(spawner.position, goal.position, NavMesh.AllAreas, path))
            {
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    invalidMapMessage.SetActive(false);
                    validMapMessage.SetActive(true);
                    confirmButton.interactable = true;
                    pathButton.interactable = false;
                    pathComplete = true;
                }
                else
                {
                    invalidMapMessage.SetActive(true);
                    validMapMessage.SetActive(false);
                    confirmButton.interactable = false;
                    pathComplete = false;
                    pathButton.interactable= true;
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


