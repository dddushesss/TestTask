using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInit
    {
        public GameInit(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            
            MenuController menuController = new MenuController(data.MenuData);
            
        }
    }
}