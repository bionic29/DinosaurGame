using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject RisingText;
    public Color TextColor, Normal, Hurt;

    CamShake Scam;


    // Start is called before the first frame update
    void Start()
    {
        GotHit = false;
        MaxHP = MaxHPAmount;
        PlayerHP = MaxHP;

        GameOver.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Scam = GameObject.FindObjectOfType<CamShake>().GetComponent<CamShake>();

        Normal = new Color(1, 1, 1, 1);
        Hurt = new Color(0.5f, 0.5f, 0.5f, 1);
        Sr.color = Normal;

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
        Sr.color = Hurt;
        RisingText.GetComponentInChildren<Text>().text = "-"+dmg.ToString("0");
        RisingText.GetComponentInChildren<Text>().color = TextColor;
        GameObject points = Instantiate(RisingText, transform.position, Quaternion.identity);
        Destroy(points, 2);

        GotHit = true;
        movespeed -= 3;
        if (PlayerHP > 0)
            Invoke(nameof(HitEnable), 3);

        if (PlayerHP <= 0)
        {
            Scam.ShakeDuration = 0f;
            Scam.ShakeAmplitude = 0;
            Scam.ShakeFrequency = 0;
            Die();
        }
    }

    void HitEnable()
    {
        movespeed += 3;
        GotHit = false;
        Sr.color = Normal;
    }

    void Die()
    {
        for(int i=0; i<=Bones.Length-1;i++)
        {
            float X = Random.Range(-8, 8);
            float Y = Random.Range(-8, 8);
            GameObject bone = Instantiate(Bones[i], transform.position, Quaternion.identity);
            bone.GetComponent<Rigidbody2D>().AddForce(new Vector2(X, Y), ForceMode2D.Impulse);
            //Destroy(bone, 10);
        }

        Scam.ShakeDuration = 0.5f;
        Scam.ShakeAmplitude = 10;
        Scam.ShakeFrequency = 3;

        Scam.ShakeCamera();
        GameOver.SetActive(true);
        Sr.gameObject.SetActive(false);
        Shadow.SetActive(false);
    }

    

}
