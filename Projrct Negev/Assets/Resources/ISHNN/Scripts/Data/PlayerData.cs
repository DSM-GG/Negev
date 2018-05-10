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
    public GearInventory inventory;
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

        inventory = new GearInventory();
        mailBox = new List<Mail>();
    }

    [System.Serializable]
    public struct GearInventory
    {
        ManualWeapon weapon_Primary;
        AutoWeapon weapon_Auto;
        Barrier barrier;
    }
}
