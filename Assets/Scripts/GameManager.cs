using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int Meteorcount;

    public int HighScore;

    public DataController data;

    MainPlayer Player;

    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        Load();
        scene = SceneManager.GetActiveScene();
        //Application.targetFrameRate = 30;
        Meteorcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.buildIndex!=0)
        {
            if (MainPlayer.PlayerHP <= 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    SceneManager.LoadScene(1);
                }
                if (Input.GetKey(KeyCode.Escape))
                {
                    SceneManager.LoadScene(0);
                }

            }
        }
    }

    public void Save()
    {
        data.playerdata.HighScore = HighScore;

        data.SavePlayerData();
    }
    public void Load()
    {
        //PlayerData data = SaveData.Loading();
        data.Load();

        HighScore = data.playerdata.HighScore;
    }

    public void SaveHighScore(int Score)
    {
        if (Score > HighScore)
        {
            HighScore = Score;
            Player = FindObjectOfType<MainPlayer>().GetComponent<MainPlayer>();
            Player.HighScoreText();
        }
        Save();
    }

}
