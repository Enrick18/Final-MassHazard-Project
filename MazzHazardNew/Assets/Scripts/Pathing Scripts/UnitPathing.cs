using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitPathing : MonoBehaviour
{
    [SerializeField] private bool isLevelEditor = false;
    //public Transform[] points;
    public List<Transform> points = new List<Transform>();
    public Block[] blocks;

    private void OnEnable()
    {
        PathCalculation.OnBlockLoaded += GetWaypoints;
    }

    private void OnDisable()
    {
        PathCalculation.OnBlockLoaded -= GetWaypoints;
    }
    public void GetWaypoints()
    {
        blocks = FindObjectsOfType<Block>();

        foreach (var block in blocks)
        {

            if (block.isWayPoint)
            {
                //points[block.wayPointIndex] = block.transform;
                points.Add(block.transform);
                points = points.OrderBy(go => go.GetComponent<Block>().wayPointIndex).ToList();
            }
        }
    }

    void Awake()
    {
        if(!isLevelEditor)
        {
            GetWaypoints();
        }
    }

}