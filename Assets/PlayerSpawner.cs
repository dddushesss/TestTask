using System;
using DefaultNamespace;
using MVCExample;
using UnityEngine;

public class PlayerSpawner
{
    private PlayerData playerData;
    private float _scale;
    private GameObject player;

    public PlayerSpawner(PlayerData playerData, float scale)
    {
        this.playerData = playerData;
        _scale = scale;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
    
    public void Spawn()
    {
       player = UnityEngine.Object.Instantiate(playerData.playerPrefab,
            new Vector3(playerData.SpawnCoord.X * _scale, playerData.offset, playerData.SpawnCoord.Y * _scale),
            Quaternion.identity);
        player.SetName("Player");
        player.AddNavMeshAgent();
    }
}