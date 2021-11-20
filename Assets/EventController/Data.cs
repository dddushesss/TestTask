using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Data", menuName = "Custom/Data", order = 0)]
    public class Data : ScriptableObject
    {
        [SerializeField] private string _mazeDataPath;
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _cameraDataPath;
        private MazeData _mazeData;
        private PlayerData _playerData;
        private CameraData _cameraData;

        public MazeData MazeData
        {
            get
            {
                if (_mazeData == null)
                {
                    _mazeData = Load<MazeData>("Data/" + _mazeDataPath);
                }

                return _mazeData;
            }
        }

        public PlayerData PlayerData
        {
            get
            {
                if (_playerData == null)
                {
                    _playerData = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _playerData;
            }
        }
        public CameraData CameraData
        {
            get
            {
                if (_cameraData == null)
                {
                    _cameraData = Load<CameraData>("Data/" + _cameraDataPath);
                }

                return _cameraData;
            }
        }
        
        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}