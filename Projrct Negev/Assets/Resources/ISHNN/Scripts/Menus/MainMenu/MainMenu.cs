﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu<MainMenu>
{
    public Button NewGameButton;
    public Button ResumeButton;

    protected override void Awake()
    {
        NewGameButton.onClick.AddListener(() => {
            NewGameMenu.Open();
        });
        ResumeButton.onClick.AddListener(() => {
            LoadMenu.Open();
        });
    }

    public override void OnBackPressed()
    {
        Application.Quit();
    }
}