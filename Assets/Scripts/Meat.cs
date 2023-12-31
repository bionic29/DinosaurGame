using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meat : MonoBehaviour
{
    public GameObject RisingText; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            MainPlayer.PlayerHP++;

            RisingText.GetComponentInChildren<Text>().text = "Heal!";
            RisingText.GetComponentInChildren<Text>().color = new Color(1, 1, 1, 1);
            GameObject points = Instantiate(RisingText, transform.position, Quaternion.identity);
            Destroy(points, 2);

            Destroy(gameObject);
        }
    }
}
