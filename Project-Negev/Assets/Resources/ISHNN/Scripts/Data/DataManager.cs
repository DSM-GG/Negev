using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour {

    public static DataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);

        //Create_StageData_JsonSample();
        //Create_Mail_JsonSample();
    }

    #region StageData

    //Json Smaple을 생성하기 위한 함수이다.
    public void Create_StageData_JsonSample()
    {
        StageData stage = new StageData(
            20,// 목표 수
            60,// 스테이지 시간
            new Mission("관할구 점거집단 무력화", "A사", "매번 생각하는 거지만 누가 대신 써주면 얼마나 좋을까..", 80000, 30000, 0),
            
            0, StageKind.Boss, "Area",

            new List<DialogCommand> {
                new DialogCommand(2,CommandKind.Dialog, new List<Dialog>{
                    new Dialog("CP", "Test, Test"),
                    new Dialog("CP", "English.")
                }),
                new DialogCommand(5,CommandKind.Dialog, new List<Dialog>{
                    new Dialog("CP", "테스트, 테스트"),
                    new Dialog("CP", "한국어다.")
                }),
            },

            new List<SpawnCommand> {
                new SpawnCommand(1,CommandKind.Enemy, new List<TempEnemy>{
                    new TempEnemy("e"),
                    new TempEnemy("a")
                }),
                new SpawnCommand(6,CommandKind.Enemy, new List<TempEnemy>{
                    new TempEnemy("e"),
                    new TempEnemy("a")
                })
            }
            );

        using (StreamWriter file = File.CreateText(string.Format("Assets/Resources/Datas/StageDatas/Stage_{0}", stage.no)))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, stage);
        }
    }

    public StageData LoadStageData(int stage_no)
    {
        using (StreamReader file = File.OpenText(string.Format("Assets/Resources/Datas/StageDatas/Stage_{0}", stage_no)))
        {
            JsonSerializer serializer = new JsonSerializer();
            StageData stage = serializer.Deserialize(file, typeof(StageData)) as StageData;
            return stage;
        }
    }

    public void saveResave()
    {
        var stage = LoadStageData(0);
        using (StreamWriter file = File.CreateText(string.Format("Assets/Resources/Datas/StageDatas/Stage_{0}_test", stage.no)))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, stage);
        }
    }

    #endregion StageData

    #region PlayerData
    //현재 이용중인 플레이어 데이터
    //플레이 중에 데이터 수정이 이루어지고, 저장시 대입되는 데이터이다.
    public static PlayerData Current_Player { get; private set; }

    //    X     프로필을 불러오는 로직에서 임시적으로 사용중이다. 이후에는 필요없음. // 플레이어 정보를 포멧에 맞추어 string으로 반환한다.
    public string LoadCurrentPlayerInfo()
    {
        return string.Format("Player Rank: {0}\nPlayer Name: {1}\nSortie : {2}\nSuccess : {3}",
            Current_Player.rank, Current_Player.player_name, Current_Player.sortie, Current_Player.success);
    }


    // .data 형식을 가지고 있는 파일을 검색해서 파일명의 목록을 List<string> 로 반환한다.
    public List<string> GetPlayerSaves()
    {
        List<string> list = new List<string>();
        DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath);
        foreach (var item in di.GetFiles())
        {
            if (item.Extension.ToLower().CompareTo(".data") == 0)
            {
                list.Add(item.Name.Replace(".data", ""));
            }
        }
        return list;
    }

    //{player_name}.data 파일을 생성하고 플레이어 데이터를 초기화해 저장한다.
    public void CreateData(string player_name)
    {
        FileStream stream = new FileStream(string.Format("{0}/{1}.data", Application.persistentDataPath, player_name), FileMode.Create);
        PlayerData data = new PlayerData(player_name);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(stream, data);

        Debug.Log(string.Format("{0}/{1}.data 저장", Application.persistentDataPath, player_name));
        stream.Close();
    }

    //Current_Player 를 {Current_Player . player_name}.data 파일에 저장한다.
    public void SaveData()
    {
        LoadMail("Save");

        FileStream stream = new FileStream(string.Format("{0}/{1}.data", Application.persistentDataPath, Current_Player.player_name), FileMode.Create);
        PlayerData data = Current_Player;

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(stream, data);

        Debug.Log(string.Format("저장 : {0}/{1}.data", Application.persistentDataPath, Current_Player.player_name));
        stream.Close();
    }

    //{player_name}.data 를 불러와 Current_Player 에 대입한다.
    public void LoadData(string player_name)
    {
        FileStream stream = File.Open(string.Format("{0}/{1}.data", Application.persistentDataPath, player_name), FileMode.Open);

        BinaryFormatter bf = new BinaryFormatter();
        Current_Player = (PlayerData)bf.Deserialize(stream);

        stream.Close();
    }
    #endregion PlayerData
    
    #region MailData
    public void Create_Mail_JsonSample()
    {
        Mail mail = new Mail("모회사", "신규 등록", "E랭크 직업이름뭘로하지로 등록 되었습니다.\n아 이런거 누가 대신 좀 써줘..축하하는 메일 좀 보내줘");
        Mail mail_2 = new Mail("Manager", "저장완료", "데이터 업데이트가 완료되었습니다. 이건 왜 메일로... *(테스트용입니다.)");

        using (StreamWriter file = File.CreateText(string.Format("Assets/Resources/Texts/Mails/{0}", "G")))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, mail);
        }
        using (StreamWriter file = File.CreateText(string.Format("Assets/Resources/Texts/Mails/{0}", "Save")))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, mail_2);
        }
    }

    //메일 인덱스로 사전에 등록된 메일을 Current_Player에 추가한다.
    public void LoadMail(string mail_index)
    {
        using (StreamReader file = File.OpenText(string.Format("Assets/Resources/Texts/Mails/{0}", mail_index)))
        {
            JsonSerializer serializer = new JsonSerializer();
            Mail mail = (Mail)serializer.Deserialize(file, typeof(Mail));
            mail.To = Current_Player.player_name;
            Current_Player.mailBox.Add(mail);
        }
        /*
        FileStream stream = File.Open(string.Format("{0}/{1}.txt", Application.dataPath + "/Resources/Texts/Mails/", mail_index), FileMode.Open);
        StreamReader sr = new StreamReader(stream, Encoding.Default);
        string[] maildata = sr.ReadToEnd().Split('/');
        stream.Close();

        Mail mail = new Mail(maildata[0], Current_Player.player_name ,maildata[1], maildata[2]);
        Current_Player.mailBox.Add(mail);
        */
    }

    //p_name을 수신자로 한 메일을 리턴한다. 직접 MailBox에 추가할 떄 불러오는 메소드.
    public Mail GetMail(string p_name, string mail_index)
    {
        using (StreamReader file = File.OpenText(string.Format("Assets/Resources/Texts/Mails/{0}", mail_index)))
        {
            JsonSerializer serializer = new JsonSerializer();
            Mail mail = (Mail)serializer.Deserialize(file, typeof(Mail));
            mail.To = p_name;
            return mail;
        }
        /*
        FileStream stream = File.Open(string.Format("{0}/{1}.txt", Application.dataPath + "/Resources/Texts/Mails/", mail_index), FileMode.Open);
        StreamReader sr = new StreamReader(stream, Encoding.Default);
        string[] maildata = sr.ReadToEnd().Split('/');
        stream.Close();

        Mail mail = new Mail(maildata[0], p_name, maildata[1], maildata[2]);
        return mail;
        */
    }
    #endregion MailData
}