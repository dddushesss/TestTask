using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInit
    {
        private List<IController> controllersToAdd;
        private Controllers _controllers;

        public delegate GameObject GETPlayer();

        public GameInit(Controllers controllers, Data data, MenuView canvas)
        {
            Time.timeScale = 0f;
            _controllers = controllers;
            controllersToAdd = new List<IController>();
            Camera camera = Camera.main;
            var menuController = new MenuController(canvas, this);

            var mazeSpawner = new MazeSpawner(data.MazeData);

            var playerSpawner = new PlayerSpawner(data.PlayerData, data.MazeData.cellSize);

            var navMeshSpawner = new NavMeshSpawner();

            var playerController =
                new PlayerControl(data.MazeData.cellSize * new Vector3(data.MazeData.mazeWidth - 2, -1, data.MazeData.mazeHeight - 2) + Vector3.one,
                    playerSpawner.GetPlayer, data.PlayerData);
            controllersToAdd.Add(playerController);

            var cameraControl = new CameraControl(camera, playerSpawner.GetPlayer, data.CameraData);
            controllersToAdd.Add(cameraControl);

            menuController.StartGameAction += mazeSpawner.SpawnMaze;
            menuController.StartGameAction += navMeshSpawner.SpawnNavMeshSurface;
            menuController.StartGameAction += playerSpawner.Spawn;
            menuController.StartGameAction += AddControllers;
            menuController.StartGameAction += cameraControl.StartFollow;
            menuController.StartGameAction += playerController.StartFollow;
        }

        private void AddControllers()
        {
            controllersToAdd.ForEach(x => _controllers?.Add(x));
        }
    }
}