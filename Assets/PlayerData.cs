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
        public float pathLineWidth;
        public Color idleColor;
        public Color defenceColor;
        public Color pathColor;
        public float explosionForce = 50f;
        public float explosionRadius;
        public float explosionUpward = 0.4f;
        public float cubeSize = 0.2f;
        public int cubesInRow = 5;
    }
}