using System.Collections.Generic;
using UnityEngine;

public enum StageKind { Destroy, Boss }
public enum CommandKind { Enemy, Dialog }

public class StageData{
    public int targetamount = 20;
    public float stagetime = 60.0f;

    public Mission mission;
    public int no;
    public StageKind kind;
    public string area;
    public List<DialogCommand> dialogCommands = new List<DialogCommand>();
    public List<SpawnCommand> spawnCommands = new List<SpawnCommand>();

    public StageData(int targetamount, float stagetime, Mission mission, int no, StageKind kind, string area,
        List<DialogCommand> dialogCommands, List<SpawnCommand> spawnCommands)
    {
        this.targetamount = targetamount;
        this.stagetime = stagetime;
        this.mission = mission;
        this.no = no;
        this.kind = kind;
        this.area = area;
        this.dialogCommands = dialogCommands;
        this.spawnCommands = spawnCommands;
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
    public List<TempEnemy> enemies;
    public SpawnCommand(float time, CommandKind kind, List<TempEnemy> enemies) : base(time, kind)
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
public struct TempEnemy
{
    //public Vector3 position;
    public string name;

    public TempEnemy(/*Vector3 position,*/ string name)
    {
        //this.position = position;
        this.name = name;
    }
}