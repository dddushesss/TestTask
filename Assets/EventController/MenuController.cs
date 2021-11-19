using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MenuController
    {
        public Action StartGameAction;
        private bool isGameStarted;
        private MenuData _menuData;

        public MenuController( MenuData menuData)
        {
            _menuData = menuData;
            menuData.starGameButton.onClick.AddListener(StartGame);
            menuData.exitButton.onClick.AddListener(Exit);
            menuData.menuButton.onClick.AddListener(ShowMenu);
        }

        private void StartGame()
        {
            if (!isGameStarted)
            {
                StartGameAction();
                isGameStarted = true;
                _menuData.starGameButton.GetComponentInChildren<Text>().text = "Продолжить";
            }
            else
            {
                Resume();
            }
            _menuData.body.SetActive(false);
        }

        private void Resume()
        {
            Time.timeScale = 1f;
        }

        private void ShowMenu()
        {
            Time.timeScale = 0f;
            _menuData.body.SetActive(true);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}