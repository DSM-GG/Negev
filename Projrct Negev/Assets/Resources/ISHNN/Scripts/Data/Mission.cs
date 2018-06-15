public class Mission
{
    public string name;
    public string owner;
    public string info;
    public float reword;
    //의뢰 착수금
    public float handsel;
    public int Stage_No;

    public Mission(string name, string owner, string info, float reword, float handsel, int stage_No)
    {
        this.name = name;
        this.owner = owner;
        this.info = info;
        this.reword = reword;
        this.handsel = handsel;
        Stage_No = stage_No;
    }
}
