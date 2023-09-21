using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour
{
    public PlayerData playerdata;
    public string filepath;

    void Awake()
    {
        filepath = Application.persistentDataPath + "/playerdata.json";

    }
    public void SavePlayerData()
    {
        string jsonData = JsonUtility.ToJson(playerdata, true);
        File.WriteAllText(filepath, jsonData);
    }
    public void ResetItemClick()
    {
        
        SavePlayerData();
        LoadPlayerData(filepath);
        Time.timeScale = 1;
        //GameManager.SceneChange = 10;
        //SceneLoad.LoadScene("Tutorial");
    }
    public void LoadPlayerData(string path2)
    {
        if (!File.Exists(path2)) { ResetItemClick(); return; }
        string jsonData = File.ReadAllText(path2);
        playerdata = JsonUtility.FromJson<PlayerData>(jsonData);
    }

    public void Load()
    {
        LoadPlayerData(filepath);
    }

    [System.Serializable]
    public class PlayerData
    {
        public int HighScore;
        public bool tutorial;
    }
}
