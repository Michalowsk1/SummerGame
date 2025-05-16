using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawners;
    [SerializeField] GameObject monster;
    int SpawnCount = 0;
    int randSpawnValue;
    int enemiesToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        enemiesToSpawn = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnCount <= enemiesToSpawn)
        {
            basicEnemy.moveSpeed = Random.Range(1.5f, 4.0f);
            randSpawnValue = Random.Range(0, spawners.Length);
            Instantiate(monster, spawners[randSpawnValue].position, monster.transform.rotation);
            SpawnCount++;
        }
    }
}
