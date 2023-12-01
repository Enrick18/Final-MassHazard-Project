using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Unity.AI.Navigation;

public class CheckPath : MonoBehaviour
{
    [SerializeField]private NavMeshSurface navMeshSurface;
    private Transform spawner; // Spawner point
    private Transform target; // End point

    public GameObject validMapUi;
    public GameObject invalidMapUi;
    public Button nextButton;

    private void OnEnable()
    {
        SelectionMenu.OnBlockEnabled += FindSpawner;
    }

    private void OnDisable()
    {
        SelectionMenu.OnBlockEnabled -= FindSpawner;
    }

    public void FindSpawner()
    {
        navMeshSurface.RemoveData();
        navMeshSurface.BuildNavMesh();

        try
        {
            spawner = GameObject.Find("Spawner").transform.GetChild(0);
            target = GameObject.Find("Goal").transform.GetChild(2);
        }
        catch 
        {
            invalidMapUi.SetActive(true);
            nextButton.interactable = false;
        }

        CheckNavmeshPath();
    }

    private void CheckNavmeshPath()
    {
        if (spawner != null && target != null)
        {
            NavMeshPath path = new NavMeshPath();

            if (NavMesh.CalculatePath(spawner.position, target.position, NavMesh.AllAreas, path)) 
            {

                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    validMapUi.SetActive(true);
                    nextButton.interactable = true;
                }
                else 
                { 
                    invalidMapUi.SetActive(true);
                    nextButton.interactable=false;
                }
            }

        }
    }


}
