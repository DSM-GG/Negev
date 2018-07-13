using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : Menu<DialogUI> {
    [SerializeField] private Text d_name;
    [SerializeField] private Text d_script;

    List<Dialog> dialogs = new List<Dialog>();

    int count = 1;

    protected override void Awake()
    {
        base.Awake();
        Time.timeScale = 0;
    }

    public void SetDIalog(string dialog_name)
    {
        dialogs = DialogManager.ReadDialog(dialog_name);
        d_name.text = dialogs[0].name;
        d_script.text = dialogs[0].content;
    }
    
    public void OnCliked()
    {
        if (count >= dialogs.Count)
        {
            Debug.Log("stop");
            count = 1;
            Time.timeScale = 1;
            MenuManager.Instance.CloseMenu();
        }
        else
        {
            Debug.Log(count);
            d_name.text = dialogs[count].name;
            d_script.text = dialogs[count].content;
            count++;
        }
    }

    public override void OnBackPressed()
    {

    }
}
