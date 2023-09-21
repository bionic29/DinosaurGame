using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePanel : MonoBehaviour
{
    public Text HiScoreText;
    GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        HiScoreText.text = "Your Current High Score : " + GM.HighScore.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ReturnMenu();
        }
    }

    public void ReturnMenu()
    {
        MainMenu.PanelOpened = false;
        gameObject.SetActive(false);
    }
}
