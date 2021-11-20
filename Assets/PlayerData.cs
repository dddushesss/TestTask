using System;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Custom/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject
    {
        public GameObject playerPrefab;
        [Serializable]
        public struct SpawnCoordStruct
        {
            public int X;
            public int Y;
        }

        public SpawnCoordStruct SpawnCoord;
        public float offset;
        public float speed;

        public Color idleColor;
        public Color defenceColor;
        public Color pathColor;
        public float pathLineWidth;
    }
}