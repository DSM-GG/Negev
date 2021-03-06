﻿using UnityEngine.UI;

public class SystemMenu : Menu<SystemMenu>
{
    public Text ProfileInfo;

    public Button SaveButton;
    public Button LoadlButton;

    protected override void Awake()
    {
        base.Awake();
        ProfileInfo.text = DataManager.Instance.LoadCurrentPlayerInfo();

        SaveButton.onClick.AddListener(() => {
            DataManager.Instance.SaveData();
        });
        LoadlButton.onClick.AddListener(() => {
            LoadMenu.Open();
        });
    }

    public override void OnBackPressed()
    {
        Close();
    }
}
