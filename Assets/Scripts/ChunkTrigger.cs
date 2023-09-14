using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController MC;

    public GameObject targetMap;

    // Start is called before the first frame update
    void Start()
    {
        MC = FindObjectOfType<MapController>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MC.currentChunk = targetMap;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (MC.currentChunk == targetMap)
            {
                MC.currentChunk = null;
            }
        }

    }
}
