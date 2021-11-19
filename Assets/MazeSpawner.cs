using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class MazeSpawner : MonoBehaviour
    {
        private MazeData _mazeData;
        [SerializeField] private GameObject cellPrefab;
        [SerializeField] private float wallOffset = 0.5f;
        [SerializeField] private int mazeWidth = 23;
        [SerializeField] private int mazeHeight = 23;
        [SerializeField] private float yOffset;
        [SerializeField] private float xOffset;
        [SerializeField] private float cellSize;

        [SerializeField] private NavMeshSurface _navMeshSurface;

        
        private void Start()
        {
            var generator = new MazeGenerator();
            var maze = generator.GenerateNewMaze(mazeWidth, mazeHeight);
            cellPrefab.transform.localScale = new Vector3(cellSize, 1, cellSize);
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    var cell = Instantiate(cellPrefab,
                        new Vector3(cellSize * x + xOffset, wallOffset, cellSize * y + yOffset),
                        Quaternion.identity).GetComponent<CellView>();
                    cell.WallLeft.SetActive(maze[x, y].WallLeft);
                    cell.WallBottom.SetActive(maze[x, y].WallBottom);
                    if (x == mazeWidth - 1 && y == 0)
                    {
                        cell.WallLeft.SetActive(false);
                    }
                }
            }


            _navMeshSurface.BuildNavMesh();
            
        }
    }
}