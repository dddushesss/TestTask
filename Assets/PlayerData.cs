using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Custom/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject
    {
        public GameObject playerPrefab;
    }
}