using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class PlayerControl : IFixedExecute
    {
        private GameObject _player;
        private Vector3 _target;
        private GameInit.GETPlayer _getPlayer;
        private PlayerData _playerData;
        private LineRenderer _playerLineRenderer;
        private NavMeshAgent _playerNavMeshAgent;

        public PlayerControl(Vector3 target, GameInit.GETPlayer getPlayer, PlayerData playerData)
        {
            _getPlayer = getPlayer;
            _playerData = playerData;
            _target = target;
        }

        public void FixedExecute(float deltaTime)
        {
            if (Math.Abs(Time.time - 2) < deltaTime)
            {
                _player.GetComponent<NavMeshAgent>().SetDestination(_target);
            }

            _playerLineRenderer.positionCount = _playerNavMeshAgent.path.corners.Length;
            for (int i = 0; i < _playerNavMeshAgent.path.corners.Length; i++)
            {
                _playerLineRenderer.SetPosition(i, _playerNavMeshAgent.path.corners[i]);
            }
        }

        public void StartFollow()
        {
            _player = _getPlayer();
            _playerLineRenderer = _player.GetComponent<LineRenderer>();
            _playerNavMeshAgent = _player.GetComponent<NavMeshAgent>();
            _player.GetComponent<MeshRenderer>().material.color = _playerData.idleColor;
            _playerLineRenderer.startWidth = _playerData.pathLineWidth;
            _playerLineRenderer.endWidth = _playerData.pathLineWidth;
            _playerLineRenderer.startColor = _playerData.pathColor;
            _playerLineRenderer.endColor = _playerData.pathColor;
        }
    }
}