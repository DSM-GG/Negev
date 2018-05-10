using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailListMenu : Menu<MailListMenu> {

    public GameObject MailLayout;
    public Button MailPrefeb;

    protected override void Awake()
    {
        base.Awake();
        foreach (Mail m in DataManager.Current_Player.mailBox)
        {
            Mail _m = m;

            Debug.Log("a");
            Button mail = Instantiate(MailPrefeb, MailLayout.transform);
            Text mailText = mail.GetComponentInChildren<Text>();
            mailText.text = string.Format("{0} : {1}", _m.From, _m.Title);

            mail.onClick.AddListener(() => {
                MailMenu.Open();
                MailMenu.Instance.SetMail(_m);
            });
        }
    }

    public override void OnBackPressed()
    {
        Close();
    }
}
