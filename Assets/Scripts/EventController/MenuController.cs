using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MenuController
    {
        public Action StartGameAction;
        private PlayerControl _playerControl;
        private GameObject _player;
        private bool isGameStarted;
        private MenuView _menuView;
        private GameInit _gameInit;

        public MenuController(MenuView menuBody, GameInit gameInit, PlayerControl playerControl)
        {
            _playerControl = playerControl;
            _menuView = menuBody;
            _gameInit = gameInit;
            
            _menuView.StartButton.onClick.AddListener(StartGame);
            _menuView.MenuButton.onClick.AddListener(ShowMenu);
            _menuView.MenuButton.onClick.AddListener(Pause);
            _menuView.ExitButton.onClick.AddListener(Exit);
            _menuView.shieldButton.onClick.AddListener(ShieldDown);
            _menuView.shieldButton.GetComponent<EventTrigger>().triggers[0].callback
                .AddListener( arg0 => ShieldUp());
            
            _menuView.shieldButton.gameObject.SetActive(false);
            _menuView.StateLable.SetActive(false);
            _menuView.MenuButton.gameObject.SetActive(false);
        }

        private void ShieldUp()
        {
            _playerControl.ShieldUp();
        }


        private void ShieldDown()
        {
            _playerControl.ShieldDown();
        }

        private void StartGame()
        {
            if (!isGameStarted)
            {
                StartGameAction();
                _menuView.StateLable.SetActive(false);
                Time.timeScale = 1f;
                isGameStarted = true;
                _menuView.StartButton.GetComponentInChildren<Text>().text = "Продолжить";
            }
            else
            {
                Resume();
            }

            _menuView.shieldButton.gameObject.SetActive(true);
            _menuView.pauseMenuBody.SetActive(false);
            _menuView.MenuButton.gameObject.SetActive(true);
        }

        public void Death()
        {
            _menuView.StateLable.SetActive(true);
            _menuView.StateLable.GetComponentInChildren<Text>().text = "Поражение";
            isGameStarted = false;
            _menuView.StartButton.GetComponentInChildren<Text>().text = "Заново";
            ShowMenu();
        }

        public void Victory()
        {
            _menuView.StateLable.GetComponentInChildren<Text>().text = "Победа!";
            isGameStarted = false;
            _menuView.StateLable.SetActive(true);
            _menuView.StartButton.GetComponentInChildren<Text>().text = "Заново";
            ShowMenu();
        }

        private void Resume()
        {
            Time.timeScale = 1f;
        }

        private void ShowMenu()
        {
            
            _menuView.pauseMenuBody.SetActive(true);
            _menuView.shieldButton.gameObject.SetActive(false);
            _menuView.MenuButton.gameObject.SetActive(false);
        }

        private void Pause()
        {
            Time.timeScale = 0f;
        }
        private void Exit()
        {
            Application.Quit();
        }
    }
}