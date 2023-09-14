using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject MeteorBody, Explode, Shadow;
    //public Rigidbody2D rb;
    Animator anim;
    Vector3 offset;
    MainPlayer player;
    Transform target;

    public float TimeofImpact,TimeofSend ,duration,Mass,Follow;

    CamShake Scam;

    float distance;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<MainPlayer>().GetComponent<MainPlayer>();
        Scam= GameObject.FindObjectOfType<CamShake>().GetComponent<CamShake>();

        offset = new Vector3(Random.Range(-20, 20), Random.Range(10, 20), 0);
        MeteorBody.transform.position = transform.position+offset;
        
        Invoke(nameof(SendMeteor), TimeofSend);
        Destroy(gameObject, duration);
    }

    void SendMeteor()
    {
        StartCoroutine(Move(MeteorBody.transform.position, transform.position, 1));
        Invoke(nameof(Hide), TimeofImpact);
    }
    void Hide()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        MeteorBody.GetComponent<SpriteRenderer>().enabled=false;
        GameObject Exp = Instantiate(Explode, transform.position, Quaternion.identity);

        if (distance < 15)
        {
            Scam.ShakeDuration = (1/distance);
            Scam.ShakeAmplitude = (15-distance) * Mass;
            Scam.ShakeFrequency = 3;
            Scam.ShakeCamera();
        }
        if(MainPlayer.PlayerHP>0)
        GameManager.Meteorcount++;

        Destroy(Exp, 3);
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Follow >= 0)
        {
            Follow -= 0.01f;
        }*/

        MeteorBody.transform.Rotate(new Vector3(0, 0, 5));
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime*Follow);
        Vector3 temp = Shadow.transform.position;
        temp.x = MeteorBody.transform.position.x;
        Shadow.transform.position = temp;

    }

    IEnumerator Move(Vector3 beginPos, Vector3 endPos, float time)
    {
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            MeteorBody.transform.position = Vector3.Lerp(beginPos, endPos, t);
            yield return null;
        }
    }
}
