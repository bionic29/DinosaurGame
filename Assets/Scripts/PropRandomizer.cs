using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> Prefabs;

    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();
    }
    void SpawnProps()
    {
        foreach(GameObject sp in propSpawnPoints)
        {
            int chance = Random.Range(0, 20);
            if (chance == 0)
            {
                int rand = Random.Range(0, Prefabs.Count);
                GameObject prop = Instantiate(Prefabs[rand], sp.transform.position, Quaternion.identity);
                prop.transform.parent = sp.transform;
            }
        }
    }
}
