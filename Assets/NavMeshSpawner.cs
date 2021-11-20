using MVCExample;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class NavMeshSpawner
    {
        
        public void SpawnNavMeshSurface()
        {
            GameObject navMeshSurface = new GameObject();
            navMeshSurface.SetName("NavMeshSurface");
            navMeshSurface.AddNavMeshSurface();
            navMeshSurface.GetComponent<NavMeshSurface>().useGeometry = NavMeshCollectGeometry.RenderMeshes;
            navMeshSurface.GetComponent<NavMeshSurface>().BuildNavMesh();   
        }
        
    }
}