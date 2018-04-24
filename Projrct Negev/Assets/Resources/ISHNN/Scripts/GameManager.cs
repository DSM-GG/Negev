using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager sInstance = null;
    public PlayerData Current_Player { get; private set; }

    public static GameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (sInstance == null)
                {
                    Debug.Log("Not Found" + sInstance.ToString());
                    return null;
                }
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        if (sInstance == null)
            sInstance = this;

        else if (sInstance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveData(string player_name)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(string.Format("{0}/{1}.data", Application.persistentDataPath, player_name), FileMode.Create);

        PlayerData data = new PlayerData(player_name);

        bf.Serialize(stream, data);

        Debug.Log(string.Format("{0}/{1}.data 저장", Application.persistentDataPath, player_name));
        stream.Close();

    }

    public List<string> GetPlayerSaves()
    {
        //스트링 말고 다르게 줄 방법은 없을까
        List<string> list = new List<string>();
        DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath);
        foreach (var item in di.GetFiles())
        {
            if (item.Extension.ToLower().CompareTo(".data") == 0)
            {
                list.Add(item.Name.Replace(".data",""));
            }
        }
        return list;
    }

    public void SetCurrentPlayer(string player_name)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = File.Open(string.Format("{0}/{1}.data", Application.persistentDataPath, player_name), FileMode.Open);

        Current_Player = (PlayerData)bf.Deserialize(stream);

        stream.Close();
    }

    //잠시 해주는 거고 나중에 형식 바뀌면 필요없음.
    public string LoadCurrentPlayerInfo()
    {
        return string.Format("Player Rank: {0}\nPlayer Name: {1}\nSortie : {2}\nSuccess : {3}",
            Current_Player.rank, Current_Player.player_name, Current_Player.sortie, Current_Player.success);
    }

    public void ChangeScene(int scene_no)
    {
        SceneManager.LoadScene(scene_no);
    }
    public void ChangeScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
