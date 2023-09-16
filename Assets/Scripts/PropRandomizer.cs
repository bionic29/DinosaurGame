using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> Prefabs;

    public GameObject Food;

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
            if (chance >=1 && chance <= 5)
            {
                int rand = Random.Range(0, Prefabs.Count);
                GameObject prop = Instantiate(Prefabs[rand], sp.transform.position+new Vector3(Random.Range(-1.5f,1.5f), Random.Range(-1.5f, 1.5f)), Quaternion.identity);
                prop.transform.parent = sp.transform;
            }
            else if (chance == 0)
            {
                Instantiate(Food, sp.transform.position, Quaternion.identity);
            }
        }
    }
}
