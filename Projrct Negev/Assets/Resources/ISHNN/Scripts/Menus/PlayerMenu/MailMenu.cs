using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailMenu : Menu<MailMenu> {

    public GameObject MailLayout;
    public Button MailPrefeb;

    protected override void Awake()
    {
        foreach (Mail m in DataManager.Current_Player.mailBox)
        {
            Button mail = Instantiate(MailPrefeb, MailLayout.transform);
            Text mailText = mail.GetComponentInChildren<Text>();
            mailText.text = string.Format("{0} : {1}",m.From, m.Subject);
        }
    }

    public override void OnBackPressed()
    {
        Close();
    }
}
