using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;


namespace DefaultNamespace
{
    public class PlayerControl : IFixedExecute, IExecute
    {
        private GameObject _player;
        private Vector3 _target;
        private GameInit.GETPlayer _getPlayer;
        private PlayerData _playerData;
        private LineRenderer _playerLineRenderer;
        private NavMeshAgent _playerNavMeshAgent;
        private bool _isShielUp = false;
        private bool _isOnTrap = false;
        private MeshRenderer _playerMeshRenderer;
        public Action OnDeath;
        private Vector3 cubesPivot;
        private bool _isInited = false;
        private float _timeStart = 0f;
        private GameObject _pieces;

        public PlayerControl(Vector3 target, GameInit.GETPlayer getPlayer, PlayerData playerData)
        {
            _getPlayer = getPlayer;
            _playerData = playerData;
            _target = target;
        }


        public void FixedExecute(float deltaTime)
        {
            if (!_isInited) return;
            
            if (Math.Abs(Time.time - _timeStart - 2) < deltaTime)
            {
                _playerNavMeshAgent.SetDestination(_target);
            }

            _playerLineRenderer.positionCount = _playerNavMeshAgent.path.corners.Length;
            for (int i = 0; i < _playerNavMeshAgent.path.corners.Length; i++)
            {
                _playerLineRenderer.SetPosition(i, _playerNavMeshAgent.path.corners[i]);
            }
        }
        
        public void Execute(float deltaTime)
        {
            if (!_isInited) return;
            
            if (_isOnTrap && !_isShielUp)
            {
                Death();
            }

            _playerMeshRenderer.material.color = _isShielUp ? _playerData.defenceColor : _playerData.idleColor;
        }

        public void InitPlayer()
        {
            _timeStart = Time.time;
            _player = _getPlayer();
            _playerLineRenderer = _player.GetComponent<LineRenderer>();
            _playerNavMeshAgent = _player.GetComponent<NavMeshAgent>();
            _playerMeshRenderer = _player.GetComponent<MeshRenderer>();
            _player.GetComponent<MeshRenderer>().material.color = _playerData.idleColor;
            _playerLineRenderer.startWidth = _playerData.pathLineWidth;
            _playerLineRenderer.endWidth = _playerData.pathLineWidth;
            _playerLineRenderer.startColor = _playerData.pathColor;
            _playerLineRenderer.endColor = _playerData.pathColor;
            _isOnTrap = false;
            _isShielUp = false;
            var cubesPivotDistance = _playerData.cubeSize * _playerData.cubesInRow / 2;
            _isInited = true;
            cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
            if (_pieces != null)
            {
                Object.Destroy(_pieces);
            }
        }

        private void Explode(Color color)
        {
            _pieces = new GameObject("Pieces");
            for (int x = 0; x < _playerData.cubesInRow; x++) {
                for (int y = 0; y < _playerData.cubesInRow; y++) {
                    for (int z = 0; z < _playerData.cubesInRow; z++) {
                        CreatePiece(x, y, z, color);
                    }
                }
            }

            
            Vector3 explosionPos =  _player.transform.position;
            
            Collider[] colliders = Physics.OverlapSphere(explosionPos, _playerData.explosionRadius);
            
            foreach (Collider hit in colliders) {
              
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null) {
                    
                    rb.AddExplosionForce(_playerData.explosionForce, _player.transform.position, _playerData.explosionRadius, _playerData.explosionUpward);
                }
            }

        }

        private  void CreatePiece(int x, int y, int z, Color color) {

            
            GameObject piece;
            
            piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
            piece.transform.SetParent(_pieces.transform);
            piece.transform.position =  _player.transform.position + new Vector3(_playerData.cubeSize * x, _playerData.cubeSize * y, _playerData.cubeSize * z) - cubesPivot;
            piece.transform.localScale = new Vector3(_playerData.cubeSize, _playerData.cubeSize, _playerData.cubeSize);

            piece.GetComponent<MeshRenderer>().material.color = color;
            piece.AddComponent<Rigidbody>();
            piece.GetComponent<Rigidbody>().mass = _playerData.cubeSize;
            
        }

        private void Death()
        {
            _isInited = false;
            OnDeath.Invoke();
            
            Explode(_playerData.idleColor);
            Object.Destroy(_player);
        }

        public void Victory()
        {
            _isInited = false;
            Explode(_playerData.defenceColor);
            Object.Destroy(_player);
        }
        
        public void ShieldUp()
        {
            _isShielUp = true;
        }

        public void ShieldDown()
        {
            _isShielUp = false;
        }

        public void OnTrapEnter()
        {
            _isOnTrap = true;
        }

        public void OnTrapExit()
        {
            _isOnTrap = false;
        }

        
    }
}