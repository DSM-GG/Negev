﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
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
    }

    #region MapData / Json

    //Json Smaple을 생성하기 위한 함수이다.
    /*
    public void Create_StageData_JsonSample()
    {
        StageData stage = new StageData(0, StageKind.Boss, "Area",
            new List<Command> {
                new DialogCommand(5,CommandKind.Dialog, new List<Dialog>{
                    new Dialog("CP", "Test, Test"),
                    new Dialog("CP", "한국어다.")
                }),
                new SpawnCommand(5,CommandKind.Enemy, new List<Enemy>{
                    new Enemy("e"),
                    new Enemy("a")
                })
            });

        using (StreamWriter file = File.CreateText(string.Format("Assets/Resources/Datas/StageDatas/Stage_{0}", stage.no)))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, stage);
        }
    }
    */

    public StageData GetStageData(int stage_no)
    {
        using (StreamReader file = File.OpenText(string.Format("Assets/Resources/Datas/StageDatas/Stage_{0}", stage_no)))
        {
            JsonSerializer serializer = new JsonSerializer();
            StageData stage = (StageData)serializer.Deserialize(file, typeof(StageData));
            return stage;
        }
    }

    #endregion MapData

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

    //MailData 는 Json으로 바꾸자.
    #region MailData
    //메일 인덱스로 사전에 등록된 메일을 Current_Player에 추가한다.
    //지금은 txt 형태를 참조.
    public void LoadMail(string mail_index)
    {
        FileStream stream = File.Open(string.Format("{0}/{1}.txt", Application.dataPath + "/Resources/Texts/Mails/", mail_index), FileMode.Open);
        StreamReader sr = new StreamReader(stream, Encoding.Default);
        string[] maildata = sr.ReadToEnd().Split('/');
        stream.Close();

        Mail mail = new Mail(maildata[0], Current_Player.player_name ,maildata[1], maildata[2]);
        Current_Player.mailBox.Add(mail);
    }

    //p_name을 수신자로 한 메일을 리턴한다. 직접 MailBox에 추가할 떄 불러오는 메소드.
    public Mail GetMail(string p_name, string mail_index)
    {
        FileStream stream = File.Open(string.Format("{0}/{1}.txt", Application.dataPath + "/Resources/Texts/Mails/", mail_index), FileMode.Open);
        StreamReader sr = new StreamReader(stream, Encoding.Default);
        string[] maildata = sr.ReadToEnd().Split('/');
        stream.Close();

        Mail mail = new Mail(maildata[0], p_name, maildata[1], maildata[2]);
        return mail;
    }
    #endregion MailData

    public void LoadStageData()
    {

    }
}