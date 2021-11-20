﻿using UnityEngine;
using UnityEngine.AI;

namespace MVCExample
{
    public static partial class BuilderExtension
    {

        public static GameObject AddNavMeshSurface(this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<NavMeshSurface>();
            return gameObject;
        } 
        public static GameObject AddLineRenderer(this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<LineRenderer>();
            return gameObject;
        } 
        
        
        public static GameObject AddNavMeshAgent(this GameObject gameObject, float speed)
        {
            var component = gameObject.GetOrAddComponent<NavMeshAgent>();
            component.speed = speed;
            return gameObject;
        }
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}
