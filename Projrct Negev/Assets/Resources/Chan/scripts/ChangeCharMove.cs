using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharMove : MonoBehaviour
{
    private float CharacterMoveSpeed = 15f;
    public GameObject Cube;


    public const int X_MIN = -20, X_MAX = 20, Z_MIN = -8, Z_MAX = 12;

    public enum MoveMode { Side = 0, TopBack };
    public MoveMode mode;
    public Camera camera;

    // Use this for initialization
    void Start()
    {
        mode = MoveMode.TopBack;
    }

    // Update is called once per frame
    public void Update()
    {
        MoveChange();
    }
    public Vector3 LimitPosition(Vector3 vector)
    {
        Vector3 pos = CameraManager.current.WorldToViewportPoint(vector);
        
        pos.x = Mathf.Clamp(pos.x, X_MIN, X_MAX);
        pos.z = Mathf.Clamp(pos.z, Z_MIN, Z_MAX);

        return CameraManager.current.ViewportToWorldPoint(pos);
    }

    void MoveChange()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            mode = MoveMode.Side;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            mode = MoveMode.TopBack;
        }

        if (mode == MoveMode.Side)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(new Vector3(0, 0, 1) * CharacterMoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(new Vector3(-1, 0, 0) * CharacterMoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(new Vector3(1, 0, 0) * CharacterMoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(new Vector3(0, 0, -1) * CharacterMoveSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                CharacterMoveSpeed = 5f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                CharacterMoveSpeed = 20f;
            }
        }

        if (mode == MoveMode.TopBack)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(new Vector3(0, 0, 1) * CharacterMoveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(new Vector3(-1, 0, 0) * CharacterMoveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(new Vector3(1, 0, 0) * CharacterMoveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(new Vector3(0, 0, -1) * CharacterMoveSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                CharacterMoveSpeed = 5f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                CharacterMoveSpeed = 20f;
            }
        }
    }
}