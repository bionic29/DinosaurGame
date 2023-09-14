using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPIndicator : MonoBehaviour
{
    Text CountText;
    MainPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        CountText = GetComponent<Text>();
        player = GameObject.FindObjectOfType<MainPlayer>().GetComponent<MainPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        CountText.text = "HP : " + MainPlayer.PlayerHP.ToString("0")+"/"+ MainPlayer.MaxHP;

        if (MainPlayer.PlayerHP > MainPlayer.MaxHP)
            MainPlayer.PlayerHP = MainPlayer.MaxHP;
    }
}
