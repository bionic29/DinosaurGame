using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public int damage;
    public MainPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<MainPlayer>().GetComponent<MainPlayer>();
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!MainPlayer.GotHit)
            {
                player.DamagePlayer(damage);
            }
        }
    }
}
