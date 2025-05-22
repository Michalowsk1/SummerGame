using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngineInternal;

public class flyingEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [SerializeField] GameObject target;

    public NavMeshAgent agent;

    void Start()
    {
        target = GameObject.Find("/Player");
    }

    // Update is called once per frame
    void Update()
    {

        transform.eulerAngles = new Vector3(target.transform.rotation.x, target.transform.rotation.y, 25.0f);

        agent.SetDestination(target.transform.position);


    }

}
