﻿using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class MazeSpawner
    {
        private MazeData _mazeData;

        public MazeSpawner(MazeData mazeData)
        {
            _mazeData = mazeData;
        }

        public void SpawnMaze()
        {
            var generator = new MazeGenerator();
            var maze = generator.GenerateNewMaze(_mazeData.mazeWidth, _mazeData.mazeHeight, _mazeData.TrapPercent);
            _mazeData.cellPrefab.transform.localScale = new Vector3(_mazeData.cellSize, 1, _mazeData.cellSize);
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    var cell = Object.Instantiate(_mazeData.cellPrefab,
                        new Vector3(_mazeData.cellSize * x + _mazeData.xOffset, _mazeData.wallOffset,
                            _mazeData.cellSize * y + _mazeData.yOffset),
                        Quaternion.identity).GetComponent<CellView>();
                    cell.WallLeft.SetActive(maze[x, y].WallLeft);
                    cell.WallBottom.SetActive(maze[x, y].WallBottom);
                    cell.Floor.SetActive(maze[x, y].Floor);
                    cell.TrapTrigger.SetActive(maze[x,y].IsATrap);
                    if (maze[x, y].IsATrap)
                    {
                        cell.Floor.GetComponent<MeshRenderer>().material.color = _mazeData.trapColor;
                    }
                    if (x == _mazeData.mazeWidth - 2 && y == _mazeData.mazeHeight - 2)
                    {
                        cell.Floor.GetComponent<MeshRenderer>().material.color = _mazeData.finishColor;
                    }
                }
            }
        }
    }
}