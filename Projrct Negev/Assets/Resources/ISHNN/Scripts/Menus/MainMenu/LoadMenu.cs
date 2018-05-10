using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenu : Menu<LoadMenu>
{
    public GameObject ProfileLayout;
    public Button ProfilePrefeb;

    public Text ProfileInfo;

    public Button LoadButton;
    public Button ExitButton;

    protected override void Awake()
    {
        base.Awake();
        ExitButton.onClick.AddListener(() =>
        {
            this.OnBackPressed();
        });

        List<string> playerList = DataManager.Instance.GetPlayerSaves();
        //     #      로직수정필요. //이름 리스트 받고 그 이름으로 다시 로드
        foreach (string name in playerList)
        {
            Button profile = Instantiate(ProfilePrefeb, ProfileLayout.transform);
            profile.name = string.Format("Profile:{0}", name);
            profile.onClick.AddListener(() => {
                DataManager.Instance.LoadData(name);
                ProfileInfo.text = DataManager.Instance.LoadCurrentPlayerInfo();

                LoadButton.onClick.AddListener(() =>
                {
                    GameManager.Instance.SendMessage("ChangeScene", "GameMenu");
                });
            });

            Text playername = profile.GetComponentInChildren<Text>();
            playername.text = name;
        }
    }

    public override void OnBackPressed()
    {
        MenuManager.Instance.CloseMenu();
    }
}