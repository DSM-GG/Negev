using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public enum Cameramode { Side = 0, TopBack };
    public Cameramode cmode;
 
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.0f, 7.0f), 0, Mathf.Clamp(transform.position.z, -4.0f, 4.0f));
    }
    void Camerachange()
    {
        if (Input.GetKey(KeyCode.O))
        {
            cmode = Cameramode.Side;
        }
        else if (Input.GetKey(KeyCode.P))
        {
            cmode = Cameramode.TopBack;
        }
        if (cmode == Cameramode.Side)
        {
           
        }
        if (cmode == Cameramode.TopBack)
        {
           
        }
    }
}
