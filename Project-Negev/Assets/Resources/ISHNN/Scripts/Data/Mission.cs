public class Mission
{
    public string name;
    public string owner;
    public string info;
    public float reward;
    //의뢰 착수금
    public float handsel;
    public int Stage_No;

    /// <summary>
    /// 뀨
    /// </summary>
    /// <param name="name"></param>
    /// <param name="owner"></param>
    /// <param name="info"></param>
    /// <param name="reword"></param>
    /// <param name="handsel"></param>
    /// <param name="stage_No"></param>
    public Mission(string name, string owner, string info, float reward, float handsel, int stage_No)
    {
        this.name = name;
        this.owner = owner;
        this.info = info;
        this.reward = reward;
        this.handsel = handsel;
        Stage_No = stage_No;
    }
}
