using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMenu : Menu<SystemMenu>
{
    public Text ProfileInfo;

    public Button SaveButton;
    public Button LoadlButton;

    protected override void Awake()
    {
        ProfileInfo.text = GameManager.Instance.LoadCurrentPlayerInfo();

        SaveButton.onClick.AddListener(() => {
            //세이브 구현필요
            Debug.Log("Save구현필요.");
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
