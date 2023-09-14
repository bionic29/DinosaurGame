using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public float movespeed;
    public Vector3 movement;
    Rigidbody2D rb;
    public SpriteRenderer Sr;
    public GameObject Shadow, GameOver;
    Animator anim;

    public GameObject[] Bones;

    public static int PlayerHP, MaxHP;
    public static bool GotHit;

    public int MaxHPAmount;

    public Vector2 MoveDir; 

    // Start is called before the first frame update
    void Start()
    {
        GotHit = false;
        MaxHP = MaxHPAmount;
        PlayerHP = MaxHP;

        GameOver.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP > 0)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            //MoveDir = new Vector2(movement.x, movement.y).normalized;
        }
        else if (PlayerHP <= 0)
        {
            movement.x = 0;
            movement.y = 0;
            rb.velocity = Vector2.zero;
        }
        

        if (movement.x != 0 || movement.y != 0)
        {
            //transform.position += new Vector3(movement.x, movement.y, 0) * movespeed * Time.deltaTime;
            rb.velocity = movement.normalized* movespeed;
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
            rb.velocity = Vector2.zero;
        }

        if (movement.x > 0)
            Sr.flipX = false;
        else if (movement.x < 0)
            Sr.flipX = true;
    }

    public void DamagePlayer(int dmg)
    {
        PlayerHP -= dmg;
        GotHit = true;
        if (PlayerHP > 0)
            Invoke(nameof(HitEnable), 3);

        if (PlayerHP <= 0)
            Die();
    }

    void HitEnable()
    {
        GotHit = false;
    }

    void Die()
    {
        for(int i=0; i<=Bones.Length-1;i++)
        {
            float X = Random.Range(-8, 8);
            float Y = Random.Range(-8, 8);
            GameObject bone = Instantiate(Bones[i], transform.position, Quaternion.identity);
            bone.GetComponent<Rigidbody2D>().AddForce(new Vector2(X, Y), ForceMode2D.Impulse);
            Destroy(bone, 10);
        }
        GameOver.SetActive(true);
        Sr.gameObject.SetActive(false);
        Shadow.SetActive(false);
    }

}
