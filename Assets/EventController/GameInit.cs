using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInit
    {
        private List<IController> controllersToAdd;
        private Controllers _controllers;
        public GameInit(Controllers controllers, Data data, MenuView canvas)
        {
            _controllers = controllers;
            controllersToAdd = new List<IController>();
            Camera camera = Camera.main;
            var menuController = new MenuController(canvas);

            var mazeSpawner = new MazeSpawner(data.MazeData);
            
            var playerSpawner = new PlayerSpawner(data.PlayerData, data.MazeData.cellSize);
            
            var navMeshSpawner = new NavMeshSpawner();

            var playerController = new PlayerControl(playerSpawner.GetPlayer(),
                data.MazeData.cellSize * new Vector3(data.MazeData.mazeWidth - 1, 0, 0));
            controllersToAdd.Add(playerController);
            menuController.StartGameAction += mazeSpawner.SpawnMaze;
            menuController.StartGameAction += navMeshSpawner.SpawnNavMeshSurface;
            menuController.StartGameAction += playerSpawner.Spawn;
            menuController.StartGameAction += addControllers;
        }

        private void addControllers()
        {
            controllersToAdd.ForEach(x => _controllers?.Add(x));
        }
    }
}