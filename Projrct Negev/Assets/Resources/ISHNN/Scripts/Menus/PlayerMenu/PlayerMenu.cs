using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : Menu<PlayerMenu> {
    public Button GearButton;
    public Button ShoplButton;
    public Button MissionButton;
    public Button MailButton;
    public Button SystemButton;

    protected override void Awake()
    {
        base.Awake();
        SystemButton.onClick.AddListener(() => {
            SystemMenu.Open();
        });
    }

    public override void OnBackPressed()
    {
        //메인메뉴로 나가기 전 질문 후 나가기 +
        GameManager.Instance.SendMessage("ChangeScene", "MainMenu");
    }
}
