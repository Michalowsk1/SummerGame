using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngineInternal;

public class flyingEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject death;
    [SerializeField] GameObject pointDrop;

    [SerializeField] GameObject target;

    public NavMeshAgent agent;
    float hp;
    bool hit = false;

    void Start()
    {
        target = GameObject.Find("/Player");
        hp = 5;
    }

    // Update is called once per frame
    void Update()
    {

        transform.eulerAngles = new Vector3(target.transform.rotation.x, target.transform.rotation.y, 25.0f);

        agent.SetDestination(target.transform.position);

        if (hit)
        {
            hp -= playerAttack.dmg;
            healthBar.transform.localScale = new Vector3((0.25f * hp), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
            hit = false;
        }

        if(hp == 0)
        {
            Destroy(gameObject);
            GameObject prefab = Instantiate(death, gameObject.transform.position, Quaternion.identity);
            Destroy(prefab, 0.2f);

            for (int i = 0; i < Random.Range(2, 6); i++)
            {
                GameObject loot = Instantiate(pointDrop, gameObject.transform.position, Quaternion.identity);
                Rigidbody2D lootrb = loot.GetComponent<Rigidbody2D>();
                lootrb.velocity = (new Vector2(Random.Range(-50, 50), Random.Range(-50, 50)));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            hit = true;
        }
    }

}
