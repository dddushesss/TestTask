using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraControl : IFixedExecute
    {
        private Camera _camera;
        
        private GameInit.GETPlayer _getPlayer;
        
        private Transform _target;
        private Vector3 _offset;
        private float _smoothSpeed;
        
        public CameraControl(Camera camera,  GameInit.GETPlayer getPlayer, CameraData cameraData)
        {
            _camera = camera;
            _getPlayer = getPlayer;
            _offset = cameraData.offset;
            _smoothSpeed = cameraData.smoothSpeed;
        }

        public void StartFollow()
        {
            _target = _getPlayer().transform;
        }

        public void FixedExecute(float deltaTime)
        {
            if(_target == null)
                return;
            Vector3 desiredPosition = _target.position + _offset;
            Vector3 smothedPosition = Vector3.Lerp(_camera.transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
            _camera.transform.position = smothedPosition;
            _camera.transform.LookAt(_target);
        }
    }
}