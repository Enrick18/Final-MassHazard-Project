using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int gridSizeX = 5;
    public int gridSizeY = 5;
    public int gridSizeZ = 5;
    public float spacing = 1.0f;

    void Awake()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for(int x = 0; x < gridSizeX; x++)
        {
            for(int y = 0; y < gridSizeY; y++)
            {
                for(int z = 0; z < gridSizeZ; z++)
                {
                    Vector3 spawnPosition = new Vector3(x * spacing, y * spacing, z * spacing);
                    GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                    cube.transform.parent = transform;
                }
            }
        }
    }
}
