using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    void Start()
    {
        target = GameObject.Find("/Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);

        transform.eulerAngles = new Vector3(target.transform.rotation.x, target.transform.rotation.y, 25.0f);
    }
}
