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
        private string _playerDataPath;
        private string _menuDataPath;
        private MazeData _mazeData;
        private PlayerData _playerData;
        private MenuData _menuData;

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

        public MenuData MenuData
        {
            get
            {
                if (_menuData == null)
                {
                    _menuData = Load<MenuData>("Data/" + _playerDataPath);
                }

                return _menuData;
            }
        }


        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}