using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "MenuData", menuName = "Custom/Menu Data", order = 3)]
    public class MenuData : ScriptableObject
    {
        public Button starGameButton;
        public Button exitButton;
        public GameObject body;
        public Button menuButton;
    }
}