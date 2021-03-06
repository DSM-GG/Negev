﻿using UnityEngine.UI;

public class NewGameMenu : Menu<NewGameMenu>
{
    public Button CreateButton;
    public Text nameInput;

    protected override void Awake()
    {
        base.Awake();
        CreateButton.onClick.AddListener(() => {
            string player_name = nameInput.text;

            DataManager.Instance.CreateData(player_name);
            DataManager.Instance.LoadData(player_name);
            
            DataManager.Instance.SaveData();

            GameManager.Instance.SendMessage("ChangeScene", "GameMenu");
        });
    }

    public override void OnBackPressed()
    {
        MenuManager.Instance.CloseMenu();
    }
}
