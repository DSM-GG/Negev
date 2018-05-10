using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager sInstance = null;

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

    public void ChangeScene(int scene_no)
    {
        SceneManager.LoadScene(scene_no);
    }
    public void ChangeScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
