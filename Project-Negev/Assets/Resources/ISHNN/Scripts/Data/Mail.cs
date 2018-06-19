[System.Serializable]
public class Mail{
    public string From;
    public string To;
    public string Title;
    public string Content;

    public Mail(string from, string subject, string content)
    {
        From = from;
        Title = subject;
        Content = content;
    }
}
