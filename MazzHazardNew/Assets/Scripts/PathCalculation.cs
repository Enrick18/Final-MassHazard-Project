using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathCalculation : MonoBehaviour
{
    public Transform spawner; // Spawner point
    public Transform target; // End point
    public List<GameObject> scannedBlocks = new List<GameObject>();
    public static event Action OnBlockLoaded;

    private void OnEnable()
    {
        LoadMap.OnMapLoaded += FindSpawner;
    }

    private void OnDisable()
    {
        LoadMap.OnMapLoaded -= FindSpawner;
    }

    private void Start()
    {
        
    }

    private void FindSpawner()
    {
        spawner = GameObject.Find("Spawner").transform.GetChild(0);
        target = GameObject.Find("Goal").transform.GetChild(2);

        if (spawner == null)
        {
            Debug.Log("Spawner is not found");
        }

        if (target == null)
        {
            Debug.Log("Goal is not found");
        }
        FindPath();
    }

    private void FindPath()
    {
        if (spawner != null && target != null)
        {
            NavMeshPath path = new NavMeshPath();

            if (NavMesh.CalculatePath(spawner.position, target.position, NavMesh.AllAreas, path))
            {
                int count = -1;
                //Debug.Log(path.corners.Length);
                foreach (Vector3 point in path.corners)
                {
                    
                    //Debug.Log(point);
                    RaycastHit hit;
                    if (Physics.Raycast(point, Vector3.down, out hit, Mathf.Infinity))
                    {
                        
                        // 'hit.collider.gameObject' is the block along the path
                        GameObject block = hit.collider.gameObject;
                        //Debug.Log("Connected block: " + block.name + " Parent: " + block.transform.parent.gameObject);

                        if (block.GetComponent<Block>()) 
                        {
                            count++;
                            var blockSetter = block.GetComponent<Block>();

                            blockSetter.isWayPoint = true;
                            blockSetter.wayPointIndex = count;
                            //Debug.Log(count);
                        }

                    }
                }

            }
        }
        OnBlockLoaded?.Invoke();
    }
}