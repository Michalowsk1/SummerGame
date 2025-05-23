using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class flyingProj : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D rb;

    bool spawn = true;
    Vector2 direction;

    void Start()
    {
        target = GameObject.Find("/Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            direction = (target.transform.position - gameObject.transform.position).normalized;
            spawn = false;
        }

        rb.velocity = new Vector2 (direction.x * 10, direction.y * 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bar" || collision.gameObject.tag == "cave" || collision.gameObject.tag == "heal" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
