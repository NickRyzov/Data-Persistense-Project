using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Store : MonoBehaviour
{
    public MainMenu mainMenu;

    public static Store instanse;
    static string playerName;
    static string championName = "Mr.Nobody";
    static int highScore;
    string path; 

    void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
            DontDestroyOnLoad(gameObject);
           
            path = Application.persistentDataPath + "/savefile.json";
        }
        LoadData();
    }

    public static string PLAYER_NAME
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }

    public static string CHAMPION_NAME
    {
        get
        {
            return championName;
        }
        set
        {
            championName = value;
        }
    }

    public static int HIGHSCORE
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value;
        }
    }

    public void LoadData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            PLAYER_NAME = data.currentPlayerName;
            HIGHSCORE = data.highScore;
            CHAMPION_NAME = data.championName;
            mainMenu.Display();
        }
    }

    public void SaveD()
    {
        SaveData sd = new SaveData();
        sd.highScore = highScore;
        sd.championName = championName;
        sd.currentPlayerName = playerName;

        string json = JsonUtility.ToJson(sd);
        File.WriteAllText(path, json);
    }

    [SerializeField]
    class SaveData
    {
        public int highScore;
        public string championName;
        public string currentPlayerName;
    }


    
}
