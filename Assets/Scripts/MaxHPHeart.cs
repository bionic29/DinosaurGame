using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHPHeart : MonoBehaviour
{
    public GameObject RisingText;
    // Start is called before the first frame update
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            MainPlayer.MaxHP++;

            RisingText.GetComponentInChildren<Text>().text = "MaxHP +1 !";
            RisingText.GetComponentInChildren<Text>().color = new Color(1, 1, 1, 1);
            GameObject points = Instantiate(RisingText, transform.position, Quaternion.identity);
            Destroy(points, 2);

            Destroy(gameObject);
        }
    }
}
