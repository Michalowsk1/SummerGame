using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    GameObject player;
    [SerializeField] Rigidbody2D rb;

    Vector2 Direction;
    void Start()
    {
        player = GameObject.Find("/Player");
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Direction = ((player.transform.position - gameObject.transform.position).normalized);
        if((Vector3.Distance(gameObject.transform.position, player.transform.position)) < 2f)
        {
            rb.velocity = (new Vector2(Direction.x, Direction.y) * 3);
        }
        else rb.velocity = Vector3.zero;

        if ((Vector3.Distance(gameObject.transform.position, player.transform.position)) < 1f)
        {
            PointSystem.pointCount++;
            Destroy(gameObject);
        }
    }
}
