using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public Camera Main_Camera;
    public Camera Second_Camera;

    public static Camera current = null;

    public void Start()
    {
        current = Main_Camera;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Main_Camera.enabled = false;
            Second_Camera.enabled = true;
            current = Second_Camera;
        }

        if (Input.GetKey(KeyCode.W))
        {   
            Main_Camera.enabled = true;
            Second_Camera.enabled = false;
            current = Main_Camera;
        }
    }
}