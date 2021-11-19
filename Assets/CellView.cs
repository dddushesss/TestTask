using UnityEngine;

namespace DefaultNamespace
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private GameObject wallLeft;
        [SerializeField] private GameObject wallBottom;

        public GameObject WallLeft => wallLeft;
        public GameObject WallBottom => wallBottom;
    }
}