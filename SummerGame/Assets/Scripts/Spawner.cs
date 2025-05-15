using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawners;
    [SerializeField] GameObject monster;
    int SpawnCount = 0;
    int randSpawnValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnCount <= 30)
        {
            basicEnemy.moveSpeed = Random.Range(1.5f, 4.0f);
            randSpawnValue = Random.Range(0, spawners.Length);
            Instantiate(monster, spawners[randSpawnValue].position, Quaternion.identity);
            SpawnCount++;
        }
    }
}
