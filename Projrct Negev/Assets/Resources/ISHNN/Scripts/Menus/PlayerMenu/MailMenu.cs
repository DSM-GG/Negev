using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailMenu : Menu<MailMenu> {

    public GameObject MailLayout;
    public Button MailPrefeb;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnBackPressed()
    {
        Close();
    }
}
