using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawners;
    [SerializeField] GameObject monster;
    int randSpawnValue;

    float time;
    float spawnFrequency;

    public static int SpawnCount;
    int entityLimit;

    // Start is called before the first frame update
    void Start()
    {
        spawnFrequency = 1.5f;
        entityLimit = 25;
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if((spawnFrequency <= time) && SpawnCount <= entityLimit)
        {
            basicEnemy.moveSpeed = Random.Range(1.5f, 4.0f);
            randSpawnValue = Random.Range(0, spawners.Length);
            Instantiate(monster, spawners[randSpawnValue].position, monster.transform.rotation);
            time = 0;
            SpawnCount++;

        }
    }
}
