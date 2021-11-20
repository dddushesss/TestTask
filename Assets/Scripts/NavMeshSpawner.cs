using MVCExample;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class NavMeshSpawner
    {
        private GameObject _navMeshSurface;

        public void Destroy()
        {
            Object.Destroy(_navMeshSurface);
        }
        public void SpawnNavMeshSurface()
        {
            _navMeshSurface = new GameObject();
            _navMeshSurface.SetName("NavMeshSurface");
            _navMeshSurface.AddNavMeshSurface();
            _navMeshSurface.GetComponent<NavMeshSurface>().useGeometry = NavMeshCollectGeometry.RenderMeshes;
            _navMeshSurface.GetComponent<NavMeshSurface>().BuildNavMesh();   
        }
        
    }
}