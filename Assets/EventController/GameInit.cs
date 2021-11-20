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
            

            var mazeSpawner = new MazeSpawner(data.MazeData);

            var playerSpawner = new PlayerSpawner(data.PlayerData, data.MazeData.cellSize);

            var navMeshSpawner = new NavMeshSpawner();

            var playerController =
                new PlayerControl(data.MazeData.cellSize * new Vector3(data.MazeData.FinishPoint.X, -1, data.MazeData.FinishPoint.Y) + Vector3.one,
                    playerSpawner.GetPlayer, data.PlayerData);
            controllersToAdd.Add(playerController);

            var cameraControl = new CameraControl(camera, playerSpawner.GetPlayer, data.CameraData);
            controllersToAdd.Add(cameraControl);
            
            var menuController = new MenuController(canvas, this, playerController);

            
            mazeSpawner.OnTrapEnter += playerController.OnTrapEnter;
            mazeSpawner.OnTrapExit += playerController.OnTrapExit;
            
            menuController.StartGameAction += mazeSpawner.SpawnMaze;
            menuController.StartGameAction += navMeshSpawner.SpawnNavMeshSurface;
            menuController.StartGameAction += playerSpawner.Spawn;
            menuController.StartGameAction += AddControllers;
            menuController.StartGameAction += cameraControl.StartFollow;
            menuController.StartGameAction += playerController.InitPlayer;

            playerController.OnDeath += menuController.Death;
            playerController.OnDeath += mazeSpawner.DestroyMaze;
            playerController.OnDeath += navMeshSpawner.Destroy;
            
            mazeSpawner.OnFinish += mazeSpawner.DestroyMaze;
            mazeSpawner.OnFinish += navMeshSpawner.Destroy;
            mazeSpawner.OnFinish += menuController.Victory;
            mazeSpawner.OnFinish += playerController.Victory;
        }

        private void AddControllers()
        {
            controllersToAdd.ForEach(x => _controllers?.Add(x));
        }
    }
}