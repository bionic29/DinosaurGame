using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreText : MonoBehaviour
{
    Text HStext;
    GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        HStext = GetComponent<Text>();
        GM = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {
        HStext.text = "High Score : " + GM.HighScore.ToString("0"); 
    }
}
