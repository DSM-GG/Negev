using System.Collections;
using System.Collections.Generic;

public enum Rank : int { A = 0, B, C, D, E};
public enum Force : int { Mi = 0, Cr, Ki};

[System.Serializable]
public class PlayerData {
    //getset과 함께 접근을 제한하는게 좋을까

    //정보조회시 확인할 수 있는 데이터
    public Rank rank;
    public string player_name;

    public int sortie;
    public int success;

    public int money;

    public float[] reliabilitys;

    //그 이외의 데이터
    public GearEquip equip;

    public Dictionary<string,Gear> armory;
    public List<Mail> mailBox;

    public PlayerData(string p_name)
    {
        this.rank = Rank.E;
        this.player_name = p_name;

        this.sortie = 0;
        this.success = 0;

        this.money = 1000;

        reliabilitys = new float[sizeof(Force)];
        for(int i = 0; i < reliabilitys.Length; i++)
        {
            reliabilitys[i] = 0;
        }

        armory = new Dictionary<string, Gear>
        {
            { "AWa" ,new ManualWeapon(001, "AWa") },
            { "BWa" ,new AutoWeapon(002, "BWa") },
            { "B" ,new Barrier(003, "B", 10, 30, Barrier.Type.Solid) },
        };

        mailBox = new List<Mail>
        {
            DataManager.Instance.GetMail(this.player_name, "G")
        };

        equip = new GearEquip
        {
            weapon_Primary = (ManualWeapon)armory["AWa"],
            weapon_Auto = (AutoWeapon)armory["BWa"],
            barrier = (Barrier)armory["B"]
        };
    }

    [System.Serializable]
    public struct GearEquip
    {
        public ManualWeapon weapon_Primary;
        public AutoWeapon weapon_Auto;
        public Barrier barrier;
    }
}
