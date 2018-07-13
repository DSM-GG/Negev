using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {
    public Text Dialog;
    public static StageManager Instance;
    static StageData CurrentStageData;
    public float timer = 0f;
    bool Spawn_bool;
    public int killedenemy = 0;
    private PrefabManager prefab;

    void Awake()
    {
        Instance = this;
        prefab = GameObject.Find("DataManager").GetComponent<PrefabManager>();
    }
	void Start () {
        //DataManager.Instance.saveResave();
        CurrentStageData = DataManager.Instance.LoadStageData(0);
        StartCoroutine(Stage());
    }

    IEnumerator Stage()
    {
        List<Command> commands = new List<Command>();

        commands.AddRange(CurrentStageData.dialogCommands.Cast<Command>());
        commands.AddRange(CurrentStageData.spawnCommands.Cast<Command>());

        //commands.OrderBy(x => x.time);
        commands.Sort((x, y) => x.time.CompareTo(y.time));

        while (commands.Count != 0)
        {
            timer += Time.deltaTime;
            if (timer >= commands[0].time)
            {
                switch (commands[0].kind)
                {
                    case CommandKind.Dialog:
                        {
                            DialogCommand command = commands[0] as DialogCommand;
                            Debug.Log(command.dialogs[0]);
                            Dialog.text = "" + command.dialogs[0].name;
                            break;
                        }
                    case CommandKind.Enemy:
                        {
                            SpawnCommand command = commands[0] as SpawnCommand;
                            Debug.Log(command.enemies[0].name);
                            GameObject enemyPrefab = prefab.GetEnemy(command.enemies[0].name);
                            try
                            {
                                Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, transform);
                            }
                            catch { }
                            //GameObject.Instantiate(Object )
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

}
