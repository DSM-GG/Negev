using UnityEngine.UI;

public class MailMenu : Menu<MailMenu> {
    public Text From;
    public Text To;
    public Text Title;
    public Text Content;

    protected override void Awake()
    {
        base.Awake();
    }

    public void SetMail(Mail mail)
    {
        From.text = mail.From;
        To.text = mail.To;
        Title.text = mail.Title;
        Content.text = mail.Content;
    }

    public override void OnBackPressed()
    {
        Close();
    }
}
