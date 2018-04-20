using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameMenu : Menu<NewGameMenu>
{
    public Button CreateButton;
    public Text nameInput;

    protected override void Awake()
    {
        CreateButton.onClick.AddListener(() => {
            string player_name = nameInput.text;
            GameManager.Instance.SendMessage("SaveData", player_name);

            GameManager.Instance.SetCurrentPlayer(player_name);
            GameManager.Instance.SendMessage("ChangeScene", 1);
        });
    }

    public override void OnBackPressed()
    {
        MenuManager.Instance.CloseMenu();
    }
}
