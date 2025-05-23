using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    bool follow;
    bool knockback = false;

    Vector2 knockbackDirection;


    void Start()
    {
        target = GameObject.Find("/Player");
        follow = true;
        agent.speed = Random.Range(2, 6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(target.transform.rotation.x, target.transform.rotation.y, 25.0f);

        if (follow)
        {
            agent.SetDestination((target.transform.position));
        }
    }
}
