
using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class PlayerControl : IFixedExecute, IInitialsation
    {
        private GameObject _player;
        private Vector3 _target;

        public PlayerControl(GameObject player, Vector3 target)
        {
            this._player = player;
            _target = target;
        }

        public void FixedExecute(float deltaTime)
        {
            if (Math.Abs(Time.time - 2) < 0.3)
            {
                
            }
        }

        public void Initialization()
        {
            _player.GetComponent<NavMeshAgent>().SetDestination(_target);
        }
    }
}