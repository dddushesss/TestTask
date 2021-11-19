using System;
using DefaultNamespace;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private int cellSpawnX;
    [SerializeField] private int cellSpawnY;
    [SerializeField] private MazeSpawner _mazeSpawner;
    [SerializeField] private Camera _camera;

    private void Start()
    {
        
    }
}
