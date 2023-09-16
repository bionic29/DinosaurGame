using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] Meteors;
    public GameObject Player;
    float timer, SpawnTime,i;
    public float Range,FirstSpawnMax, FirstSpawnMin, MaxInterval, MinSpawntime;
    //bool SpawnOK;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnOK = false;
        i = 0;
        timer = 0;
        SpawnTime = Random.Range(FirstSpawnMin,FirstSpawnMax);

    }

    // Update is called once per frame
    void Update()
    {
        i+= Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= SpawnTime)
        {
            timer = 0;
            int rand = Random.Range(0, 10);

            if(rand!=0)
            Instantiate(Meteors[Random.Range(0, Meteors.Length - 1)], Player.transform.position + new Vector3(Random.Range(-Range , Range), Random.Range(-Range , Range)), Quaternion.identity);
            else
            Instantiate(Meteors[Random.Range(0, Meteors.Length - 1)], Player.transform.position + new Vector3(Random.Range(-Range, Range)/20, Random.Range(-Range, Range) / 20), Quaternion.identity);

            SpawnTime = MaxInterval - (i/ 100)-Random.Range(0,0.2f);

            if (SpawnTime < MinSpawntime)
                SpawnTime = Random.Range(MinSpawntime, MinSpawntime+0.3f);

            if (Range < 10)
                Range += 0.1f;
            
            
        }

    }
}
