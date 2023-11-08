using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class RealtimeNavMeshBaking : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            navMeshSurface.BuildNavMesh();
        }
    }
}
