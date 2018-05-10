using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour {
    public float Max_hp = 1; // max ~~ == 최대 ~~
    public float p_hp;  // p_~~ == 현재 ~~
    public float Max_sh = 1; // sh == shield 보호막
    public float p_sh;
    // Use this for initialization

    private void Awake()
    {
        p_hp = Max_hp;
        p_sh = Max_sh;
    }
    void Start () {
		
	}

    public void UIUpdate(string _Type, string _InfoType, float _Value)
    {
        float Type = 0;
        float Maxtype = 0;

        switch (_InfoType)
        {
            case "HP":
                {
                    Type = p_hp;
                    Maxtype = Max_hp;
                    break;
                }
            case "SH":
                {
                    Type = p_sh;
                    Maxtype = Max_sh;
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter(Collider col) 
    {
        if (col.tag == "Bullet")
        {
            if (p_sh == 0)
            {
                p_hp -= Max_hp * 0.25f;
                Debug.Log("Hp = " + p_hp);
                if (p_hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                p_sh -= Max_sh * 0.25f;
                Debug.Log("Shield = " + p_sh);
            }

            Destroy(col.gameObject);
        }
    }
}
