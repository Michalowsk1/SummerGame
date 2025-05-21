using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject target;
    [SerializeField] GameObject hitFrame;
    [SerializeField] GameObject deathAnim;

    [SerializeField] GameObject healthBar;

    [SerializeField] GameObject pointDrop;

    public static float moveSpeed;

    public static float knockbackMoveSpeed = 25.0f;
    float hp;
    float dmg;
    bool hit;
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
        if(hit)
        {
            hp -= playerAttack.dmg;
            StartCoroutine(HIT());
            healthBar.transform.localScale = new Vector3((0.25f * hp), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
            hit = false;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
            GameObject Prefab = Instantiate(deathAnim, gameObject.transform.position, Quaternion.identity);
            Destroy(Prefab, 0.5f);

            for(int i = 0; i < Random.Range(1, 4); i++)
            {
                GameObject loot = Instantiate(pointDrop, gameObject.transform.position, Quaternion.identity);
                Rigidbody2D lootrb = loot.GetComponent<Rigidbody2D>();
                lootrb.velocity = (new Vector2(Random.Range(-20,20), Random.Range(-20,20)));
            }

            Spawner.SpawnCount--;
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
    }
}
