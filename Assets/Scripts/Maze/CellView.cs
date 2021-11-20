using UnityEngine;

namespace DefaultNamespace
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private GameObject wallLeft;
        [SerializeField] private GameObject wallBottom;
        [SerializeField] private GameObject floor;
        [SerializeField] private GameObject trapTrigger;

        public GameObject WallLeft => wallLeft;
        public GameObject WallBottom => wallBottom;
        public GameObject Floor => floor;
        public GameObject TrapTrigger => trapTrigger;
    }
}