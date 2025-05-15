using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject target;
    [SerializeField] GameObject hitFrame;
    [SerializeField] GameObject deathAnim;

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
        hitFrame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.transform.position - ownPos).normalized;
        ownPos = gameObject.transform.position;
        rb.velocity = (new Vector2(direction.x, direction.y) * moveSpeed);

        if(hit)
        {
            hp--;
            StartCoroutine(HIT());
            hit = false;
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
            GameObject Prefab = Instantiate(deathAnim, gameObject.transform.position, Quaternion.identity);
            Destroy(Prefab, 0.5f);
        }

    }

    IEnumerator HIT()
    {
        hitFrame.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hitFrame.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            hit = true;
        }

        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
        }
    }
}
