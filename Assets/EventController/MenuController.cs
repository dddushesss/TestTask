using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MenuController
    {
        public Action StartGameAction;
        private bool isGameStarted;
        private MenuView _menuView;

        public MenuController(MenuView menuBody)
        {
            _menuView = menuBody;
            
            _menuView.StartButton.onClick.AddListener(StartGame);
            _menuView.MenuButton.onClick.AddListener(ShowMenu);
            _menuView.ExitButton.onClick.AddListener(Exit);
            _menuView.MenuButton.gameObject.SetActive(false);
        }

        private void StartGame()
        {
            if (!isGameStarted)
            {
                StartGameAction();
                isGameStarted = true;
            }
            else
            {
                Resume();
            }

            _menuView.pauseMenuBody.SetActive(false);
            _menuView.MenuButton.gameObject.SetActive(true);
        }

        private void Resume()
        {
            Time.timeScale = 1f;
        }

        private void ShowMenu()
        {
            Time.timeScale = 0f;
            _menuView.pauseMenuBody.SetActive(true);
            _menuView.MenuButton.gameObject.SetActive(false);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}