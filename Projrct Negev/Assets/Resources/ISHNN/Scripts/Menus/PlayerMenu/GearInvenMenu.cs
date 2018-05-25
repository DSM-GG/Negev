using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearInvenMenu : Menu<GearInvenMenu>
{
    public Text Weapon_Primary;
    public Text Weapon_Auto;
    public Text Barrier;
    public Text General;

    protected override void Awake()
    {
        base.Awake();
        Weapon_Primary.text = DataManager.Current_Player.equip.weapon_Primary.name;
        Weapon_Auto.text = DataManager.Current_Player.equip.weapon_Auto.name;
        Barrier.text = DataManager.Current_Player.equip.barrier.name;
    }

    public void Start()
    {
        Debug.Log(DataManager.Current_Player.equip.weapon_Auto.name);
        Debug.Log(DataManager.Current_Player.equip.weapon_Primary.name);
        Debug.Log(DataManager.Current_Player.equip.barrier.name);
    }
    public override void OnBackPressed()
    {
        Close();
    }
}
