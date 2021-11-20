using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    public class MazeSpawner
    {
        private MazeData _mazeData;
        public Action OnTrapExit;
        public Action OnTrapEnter;
        public Action OnFinish;
        private GameObject _maze;
        
        public void DestroyMaze()
        {
            Object.Destroy(_maze);
        }

        public MazeSpawner(MazeData mazeData)
        {
            _mazeData = mazeData;
        }

        public void SpawnMaze()
        {
            _maze = Object.Instantiate(new GameObject("Maze"));
            var generator = new MazeGenerator();
            var maze = generator.GenerateNewMaze(_mazeData.mazeWidth, _mazeData.mazeHeight, _mazeData.TrapPercent, _mazeData.FinishPoint);
            _mazeData.cellPrefab.transform.localScale = new Vector3(_mazeData.cellSize, 1, _mazeData.cellSize);
            
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    
                    var cell = Object.Instantiate(_mazeData.cellPrefab,
                        new Vector3(_mazeData.cellSize * x + _mazeData.xOffset, _mazeData.wallOffset,
                            _mazeData.cellSize * y + _mazeData.yOffset),
                        Quaternion.identity, _maze.transform).GetComponent<CellView>();
                    cell.WallLeft.SetActive(maze[x, y].WallLeft);
                    cell.WallBottom.SetActive(maze[x, y].WallBottom);
                    cell.Floor.SetActive(maze[x, y].Floor);
                    
                    if (maze[x, y].IsATrap)
                    {
                        cell.TrapTrigger.SetActive(true);
                        cell.Floor.GetComponent<MeshRenderer>().material.color = _mazeData.trapColor;
                        cell.TrapTrigger.GetComponent<TrapView>().OnEnter += OnTrapEnter;
                        cell.TrapTrigger.GetComponent<TrapView>().OnExit += OnTrapExit;
                    }
                    if (x == _mazeData.mazeWidth - 2 && y == _mazeData.mazeHeight - 2)
                    {
                        
                    }

                    if (maze[x, y].IsAFinish)
                    {
                        cell.TrapTrigger.SetActive(true);
                        cell.TrapTrigger.GetComponent<TrapView>().OnEnter += OnFinish;
                        cell.Floor.GetComponent<MeshRenderer>().material.color = _mazeData.finishColor;
                    }
                }
            }
        
        }

        
        
    }
}