using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject target;

    public static float moveSpeed;
    float hp;
    float dmg;
    bool hit;

    Vector3 ownPos;
    Vector2 direction;
    void Start()
    {
        hp = 3.0f;
        dmg = 1.0f;

        target = GameObject.Find("/Player");
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.transform.position - ownPos).normalized;
        ownPos = gameObject.transform.position;
        rb.velocity = (new Vector2(direction.x, direction.y) * moveSpeed);

        if(hp <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            hp--;
        }
    }
}
