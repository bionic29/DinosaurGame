using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> BGChuncks;
    public GameObject playerObj;
    public float checkerRadius,chunkSize;
    Vector3 up, down,left,right, upright,upleft,downright,downleft;
    public LayerMask terrainMask;
    public GameObject currentChunk;

    MainPlayer player;
    
    [Header("Optimization")]
    public List<GameObject> SpawnedChuncks;
    GameObject LatestChunk;
    public float MaxOpDist; //Must be greater than Length & Width of tilemap
    float opDist, optCooldown;
    public float optCooldownDur;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MainPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunckChecker();
        ChunkOpt();
    }

    void ChunckChecker()
    {
         if (!currentChunk)
        {
            return;
        }

        if (player.movement.y != 0 || player.movement.x != 0)
        {


            up = currentChunk.transform.position + new Vector3(0, chunkSize, 0);
            down = currentChunk.transform.position + new Vector3(0, -chunkSize, 0);

            right = currentChunk.transform.position + new Vector3(chunkSize, 0, 0);
            left = currentChunk.transform.position + new Vector3(-chunkSize, 0, 0);

            upright = currentChunk.transform.position + new Vector3(chunkSize, chunkSize, 0);
            upleft = currentChunk.transform.position + new Vector3(-chunkSize, chunkSize, 0);

            downright = currentChunk.transform.position + new Vector3(chunkSize, -chunkSize, 0);
            downleft = currentChunk.transform.position + new Vector3(-chunkSize, -chunkSize, 0);

            if (!Physics2D.OverlapCircle(up, checkerRadius, terrainMask))
            {
                SpawnChunk(up);
            }
            if (!Physics2D.OverlapCircle(down, checkerRadius, terrainMask))
            {
                SpawnChunk(down);
            }
            if (!Physics2D.OverlapCircle(right, checkerRadius, terrainMask))
            {
                SpawnChunk(right);
            }
            if (!Physics2D.OverlapCircle(left, checkerRadius, terrainMask))
            {
                SpawnChunk(left);
            }
            if (!Physics2D.OverlapCircle(upright, checkerRadius, terrainMask))
            {
                SpawnChunk(upright);
            }
            if (!Physics2D.OverlapCircle(upleft, checkerRadius, terrainMask))
            {
                SpawnChunk(upleft);
            }
            if (!Physics2D.OverlapCircle(downright, checkerRadius, terrainMask))
            {
                SpawnChunk(downright);
            }
            if (!Physics2D.OverlapCircle(downleft, checkerRadius, terrainMask))
            {
                SpawnChunk(downleft);
            }



        }
    }

    void SpawnChunk(Vector3 positionToSpawn)
    {
        int rand = Random.Range(0, BGChuncks.Count);
        LatestChunk= Instantiate(BGChuncks[rand], positionToSpawn, Quaternion.identity);
        SpawnedChuncks.Add(LatestChunk);
    }

    void ChunkOpt()
    {
        optCooldown -= Time.deltaTime;

        if (optCooldown < 0)
        {
            optCooldown = optCooldownDur;
        }
        else
            return;

        foreach(GameObject chunk in SpawnedChuncks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if(opDist>MaxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
