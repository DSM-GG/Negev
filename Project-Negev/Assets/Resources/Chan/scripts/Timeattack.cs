using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeattack : MonoBehaviour {
    public float rest = 10f;
    public Text text;
	// Update is called once per frame
	void Update () {
		if(rest > 0f)
        {
            rest += Time.deltaTime;
            text.text = "Playtime : " + rest + "sec";
        }
	}
}
