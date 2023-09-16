using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerodactyle : MonoBehaviour
{
    //private Animator anim;
    bool walk, realWalk;
    public GameObject target;
    public SpriteRenderer Sr;
    Vector3 direction;
    
    public GameObject[] Bones;
    public GameObject[] Drops;

    private void Start()
    {
        walk = false;
        realWalk = false;
        target.SetActive(true);

    }

    void FixedUpdate()
    {
        direction = target.transform.position - transform.position;
        if (direction != Vector3.zero)
        {
            if (direction.x < 0)
            {
                //CharacterScale.x = -1;
                Sr.flipX = true;
            }

            if (direction.x > 0)
            {
                //CharacterScale.x = 1;
                Sr.flipX = false;
            }
        }

        if (walk == false)
        {
            Walk();
            walk = true;
        }

        if (realWalk)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime*2);
            float distancetoObj = Vector3.Distance(transform.position, target.transform.position);
            if (distancetoObj < 0.1f)
            {
                StopWalk();
            }
        }

    }

    void Walk()
    {
        target.GetComponent<MovePoint>().Shot();
        //Invoke(nameof(RealWalk), Random.Range(0.2f, 1));
        realWalk = true;
    }

    void RealWalk()
    {
        realWalk = true;
    }

    void StopWalk()
    {
        target.transform.position = transform.position;
        
        walk = false;
        realWalk = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Explode"))
        {
            for (int i = 0; i <= Bones.Length - 1; i++)
            {
                int chance = Random.Range(0, 5);
                if (chance != 0)
                {
                    float X = Random.Range(-8, 8);
                    float Y = Random.Range(-8, 8);
                    GameObject bone = Instantiate(Bones[i], transform.position, Quaternion.identity);
                    bone.GetComponent<Rigidbody2D>().AddForce(new Vector2(X, Y), ForceMode2D.Impulse);
                    Destroy(bone, 5);
                }
            }

                for (int i = 0; i <= Drops.Length - 1; i++)
            {
                int chance = Random.Range(0, 20);
                if (chance==0) 
                {
                    float X = Random.Range(-8, 8);
                    float Y = Random.Range(-8, 8);
                    GameObject drop = Instantiate(Drops[i], transform.position, Quaternion.identity);
                    drop.GetComponent<Rigidbody2D>().AddForce(new Vector2(X, Y), ForceMode2D.Impulse);

                    //Destroy(drop, 15);  
                }
            }
            Destroy(gameObject);
            Destroy(target);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall" || collision.transform.tag == "Player")
        {
            StopWalk();
        }
    }

}
