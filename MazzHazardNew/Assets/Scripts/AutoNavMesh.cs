using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AutoNavMeshBaker : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;

    void Start()
    {
        navMeshSurface.BuildNavMesh();
    }

   
}