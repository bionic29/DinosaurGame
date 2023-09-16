using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int Meteorcount;

    // Start is called before the first frame update
    void Start()
    {
        //Application.targetFrameRate = 30;
        Meteorcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (MainPlayer.PlayerHP <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
