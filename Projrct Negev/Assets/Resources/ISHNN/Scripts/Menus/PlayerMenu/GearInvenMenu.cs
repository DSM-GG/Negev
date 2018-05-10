using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearInvenMenu : Menu<GearInvenMenu>
{
    public override void OnBackPressed()
    {
        Close();
    }
}
