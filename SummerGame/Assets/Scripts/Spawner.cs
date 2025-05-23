using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawners;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject FlyingMonster;
    int randSpawnValue;

    float time;
    float spawnFrequency;

    public static int SpawnCount;
    int entityLimit;

    int enemyChooser;

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

        enemyChooser = Random.Range(0, 6);
        if((spawnFrequency <= time) && SpawnCount <= entityLimit)
        {
            if (enemyChooser <= 4)
            {
                randSpawnValue = Random.Range(0, spawners.Length);
                Instantiate(monster, spawners[randSpawnValue].position, monster.transform.rotation);
            }

            else
            {
                randSpawnValue = Random.Range(0, spawners.Length);
                Instantiate(FlyingMonster, spawners[randSpawnValue].position, monster.transform.rotation);
            }
                time = 0;
                SpawnCount++;

        }
    }
}
