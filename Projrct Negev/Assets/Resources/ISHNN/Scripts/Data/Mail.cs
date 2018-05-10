using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mail{
    public string From;
    public string To;
    public string Title;
    public string Content;

    public Mail(string from, string to, string subject, string content)
    {
        From = from;
        To = to;
        Title = subject;
        Content = content;
    }
}
