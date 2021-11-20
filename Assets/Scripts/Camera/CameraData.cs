using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "Custom/Camera Data", order = 4)]
    public class CameraData : ScriptableObject
    {
        public Vector3 offset;
        public float smoothSpeed;
    }
}