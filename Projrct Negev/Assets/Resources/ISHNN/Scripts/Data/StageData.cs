﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageKind { Distroy, Boss }
public enum CommandKind { Enemy, Dialog }

public class StageData{
    public int no;
    public StageKind kind;
    public string area;
    public List<Command> commands = new List<Command>();

    public StageData(int stage_no, StageKind stage_kind, string area, List<Command> commands)
    {
        this.no = stage_no;
        this.kind = stage_kind;
        this.area = area;
        this.commands = commands;
    }
}

public class Command {
    public float time;
    public CommandKind kind;

    public Command(float time, CommandKind kind)
    {
        this.time = time;
        this.kind = kind;
    }
}

public class DialogCommand : Command {
    public List<Dialog> dialogs;

    public DialogCommand(float time, CommandKind kind, List<Dialog>dialogs) : base(time, kind)
    {
        this.dialogs = dialogs;
    }
}

public class SpawnCommand : Command
{
    public List<Enemy> enemies;
    public SpawnCommand(float time, CommandKind kind, List<Enemy> enemies) : base(time, kind)
    {
        this.enemies = enemies;
    }
}

public struct Dialog
{
    public string name;
    public string content;

    public Dialog(string name, string content)
    {
        this.name = name;
        this.content = content;
    }
}

//임시로 사용하는 클래스로, 추후 Enemy가 완전히 구현 되면 수정.
public struct Enemy
{
    public string name;
    public Enemy(string name)
    {
        this.name = name;
    }
}