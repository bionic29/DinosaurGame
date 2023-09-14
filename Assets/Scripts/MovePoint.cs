using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    private Rigidbody2D rb;
    int movespeed, X, Y;
    Vector3 offset = new Vector3(0, -1, 0);


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        X = Random.Range(-5, 5);
        Y = Random.Range(-5, 5);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(X, Y), ForceMode2D.Impulse);

    }

    public void Shot()
    {
        rb = GetComponent<Rigidbody2D>();
        X = Random.Range(-5, 5);
        Y = Random.Range(-5, 5);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(X, Y), ForceMode2D.Impulse);
    }
}
