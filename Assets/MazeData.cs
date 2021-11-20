using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "MazeData", menuName = "Custom/MazeData", order = 1)]
    public class MazeData : ScriptableObject
    {
        public GameObject cellPrefab;
        public float wallOffset = 0.5f;
        public int mazeWidth = 23;
        public int mazeHeight = 23;
        public float yOffset;
        public float xOffset;
        public float cellSize;
        public Color finishColor;
        [Range(0, 1)] public float TrapPercent;
        public Color trapColor;

    }
}