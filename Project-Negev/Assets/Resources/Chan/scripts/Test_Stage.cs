﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Stage : MonoBehaviour {
    static StageData CurrentStageData;
    public float timer = 0f;
    public GameObject Enemy;
    bool Spawn_bool;

	// Use this for initialization
    IEnumerator Stage()
    {
        List<Command> commands = new List<Command>();
        //List<Command> commands = CurrentStageData.commands;
        while (commands.Count != 0)
        {
            timer += Time.deltaTime;
            if (timer >= commands[0].time)
            {
                switch (commands[0].kind) {
                    case CommandKind.Dialog:
                        {

                            break;
                        }
                    case CommandKind.Enemy:
                        {
                            //SpawnCommand command = commands[0] as SpawnCommand;
                            //Debug.Log(command);
                            break;
                        }
                }
                commands.RemoveAt(0);
            }

            /*Instantiate(Enemy, Vector3.zero, Quaternion.identity);
            Spawn_bool = false;

            //List<>*/
            yield return new WaitForEndOfFrame();
        }
    }

	void Start () {
        DataManager.Instance.saveResave();
        CurrentStageData = DataManager.Instance.LoadStageData(0);
        /*
        StageData stage1 = new StageData(
            new Mission("1번째 임무", "a사", "연습", 500f, 0.0f, 1),
            1, StageKind.Boss, "지역명",
            new List<Command>() { new Command(12f, CommandKind.Enemy) }
            );
            */
        Debug.Log(CurrentStageData.area);
        StartCoroutine(Stage());
    }
}
